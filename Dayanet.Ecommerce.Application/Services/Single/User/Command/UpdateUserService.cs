using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public class UpdateUserService : IUpdateUserService {
    private readonly IDataBaseContext _db;

    public UpdateUserService(IDataBaseContext db) {
        _db = db;
    }

    public async Task<ResultDto> UpdateAsync(UpdateUserDto updateUserDto) {
        var user = await _db.Users.FindAsync(updateUserDto.Id);
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }

        user.UpdateedDate = DateTime.Now;
        user.FullName = updateUserDto.FullName;
        user.Email = updateUserDto.Email;
        user.CellPhone = updateUserDto.CellPhone;
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "کاربر بروز شد"
        };
    }
}