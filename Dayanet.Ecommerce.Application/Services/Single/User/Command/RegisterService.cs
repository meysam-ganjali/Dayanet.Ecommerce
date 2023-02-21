using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.Secret;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public class RegisterService : IRegisterService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public RegisterService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<AuthResultDto>> RegisterAsync(CreateUserDto createUserDto) {
        try {
            if (string.IsNullOrWhiteSpace(createUserDto.Email)) {

                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "پست الکترونیک را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(createUserDto.CellPhone)) {

                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "شماره موبایل را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(createUserDto.FullName)) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(createUserDto.PasswordHash)) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "رمز عبور را وارد نمایید"
                };
            }
            if (createUserDto.PasswordHash != createUserDto.ConfirmPassword) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "رمز عبور و تکرار آن برابر نیست"
                };
            }
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(createUserDto.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "ایمیل خودرا به درستی وارد نمایید"
                };
            }


            var passwordHasher = new PasswordHasher();
            var hashedPassword = passwordHasher.HashPassword(createUserDto.PasswordHash);
            var user = _mapper.Map<Domain.Entities.Auth.User>(createUserDto);
            user.PasswordHash = hashedPassword;
            user.EmailConfirmed = false;
            user.RoleId = 2;
            user.PhoneNumberConfirmed = false;
            user.LockoutEnabled = false;
            user.IsActive = true;
            await _db.Users.AddAsync(user);

            await _db.SaveChangesAsync();

            return new ResultDto<AuthResultDto>() {
                Data = new AuthResultDto {
                    CellPhone = user.CellPhone,
                    Email = user.Email,
                    FullName = user.FullName,
                    Id = user.Id,
                },
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد",
            };
        } catch (Exception) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "ثبت نام انجام نشد !"
            };
        }
    }
}