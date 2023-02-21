using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Repository.User;

public class ActivityUserRepository : IActivityUserRepository {
    private readonly IDataBaseContext _db;


    public ActivityUserRepository(IDataBaseContext db) {
        _db = db;
    }

    public async Task<ResultDto> LockOnLockAsync(long id) {
        var user = await _db.Users.FindAsync(id);
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
        user.LockoutEnabled = !user.LockoutEnabled;
        user.LockoutEnd = DateTime.Now;
        user.UpdateedDate = DateTime.Now;
        string userstate = user.LockoutEnabled == true ? "قفل کاربر فعال شد" : "قفل کاربر باز شد";
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = userstate
        };
    }

    public async Task<ResultDto> ActiveDeActiveAsync(long id) {
        var user = await _db.Users.FindAsync(id);
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
        user.IsActive = !user.IsActive;
        user.UpdateedDate = DateTime.Now;
        string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = $"کاربر {userstate} شد"
        };
    }

    public async Task<ResultDto> ChangeRoleAsync(long UserId, int RoleId)
    {
        var role = await _db.Roles.FindAsync(RoleId);
        var user = await _db.Users.FindAsync(UserId);
        if (role == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "نقش یافت نشد"
            };
        }
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
        user.Role = role;
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = $"نقش کاربر {user.FullName} به نقش {role.Name} تغییر کرد"
        };
    }
}