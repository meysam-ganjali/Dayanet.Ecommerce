using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.Secret;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public class LoginService : ILoginService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public LoginService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<AuthResultDto>> LoginAsync(LoginDto loginDto) {
        if (string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password)) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "نام کاربری و رمز عبور را وارد نمایید",
            };
        }



        var user = await _db.Users
            .Include(p => p.Role)
            .FirstOrDefaultAsync(p => (p.CellPhone.Equals(loginDto.UserName) || p.Email.Equals(loginDto.UserName)) 
                                      && p.IsActive == true);

        if (user == null) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "کاربری با این ایمیل در سایت فروشگاه  ثبت نام نکرده است",
            };
        }
        var passwordHasher = new PasswordHasher();
        bool resultVerifyPassword = passwordHasher.VerifyPassword(user.PasswordHash, loginDto.Password);
        if (resultVerifyPassword == false) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "رمز وارد شده اشتباه است!",
            };
        }

        user.LastLoginDateTime = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto<AuthResultDto>() {
            Data = new AuthResultDto {
                CellPhone = user.CellPhone,
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                RoleName = user.Role.Name
            },
            IsSuccess = true,
            Message = "ورود به سایت با موفقیت انجام شد",
        };
    }
}