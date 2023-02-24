using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.Secret;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public class CreateUserAdminService : ICreateUserAdminService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public CreateUserAdminService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateUserAdminAsync(CreateUserDto userDto) {
        Domain.Entities.Auth.User user = _mapper.Map<Domain.Entities.Auth.User>(userDto);
        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(userDto.PasswordHash);
        user.PasswordHash = hashedPassword;
        try {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = "کاربر جدید اضافه شد"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = true,
                Message = e.Message
            };
        }

    }
}