using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public class DeleteUserService : IDeleteUserService {
    private readonly IDataBaseContext _db;

    public DeleteUserService(IDataBaseContext db) {
        _db = db;
    }

    public async Task<ResultDto> RemoveAsync(long id) {
        var user = await _db.Users
            .Include(x => x.UserAddresses)
            .Include(x => x.Favorits)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربری با این مشخصات یافت نشد"
            };
        }

        if (user.UserAddresses.Count > 0) {
            foreach (var address in user.UserAddresses) {
                _db.UserAddresses.Remove(address);
            }
        }

        if (user.Favorits.Count > 0) {
            foreach (var f in user.Favorits) {
                _db.Favorits.Remove(f);
            }
        }

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "عملیات حذف کاربر با موفقیت به پایان رسید"
        };
    }
}