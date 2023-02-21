using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Repository.Role;

public class RoleRepository : IRoleRepository {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public RoleRepository(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> AddAsync(CreateRoleDto role) {
        if (string.IsNullOrWhiteSpace(role.Name)) {
            return new ResultDto {
                IsSuccess = false,
                Message = "پارامتر ارسالی نامعتبر است"
            };
        }

        var roleEntity = _mapper.Map<Domain.Entities.Auth.Role>(role);
        await _db.Roles.AddAsync(roleEntity);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "نقش با موفقیت به سیستم اضافه گردید"
        };
    }

    public async Task<ResultDto> UpdateAsync(UpdateRoleDto role) {
        if (role.Id == null || role.Id <= 0) {
            return new ResultDto {
                IsSuccess = false,
                Message = "پارامتر ارسالی نامعتبر است"
            };
        }
        var roleInDb = await _db.Roles
            .Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == role.Id);
        if (roleInDb.Users.Count > 0 || roleInDb.Users.Any()) {
            return new ResultDto {
                IsSuccess = false,
                Message = "این نقش قابل ویرایش نیست زیرا کاربرانی با این نقش درسیستم فعالیت می کنند"
            };
        }

        roleInDb.Name = role.Name;
        roleInDb.UpdateedDate = DateTime.Now;
        if (role.IsShow && (roleInDb.Users.Count > 0 || roleInDb.Users.Any())) {
            return new ResultDto {
                IsSuccess = false,
                Message = "این فیلد قابل ویرایش نیست زیرا کاربرانی با این نقش درسیستم فعالیت می کنند"
            };

        } else if (role.IsShow && (roleInDb.Users.Count < 1 || !roleInDb.Users.Any())) {
            roleInDb.IsShow = role.IsShow;
        }
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "عملیات بروزرسانی با موفقیت به اتمام رسید"
        };
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        if (id == null || id <= 0) {
            return new ResultDto {
                IsSuccess = false,
                Message = "پارامتر ارسالی نامعتبر است"
            };
        }
        var role = await _db.Roles
            .Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (role.Users.Count > 0 || role.Users.Any()) {
            return new ResultDto {
                IsSuccess = false,
                Message = "این نقش قابل حذف نیست زیرا کاربرانی با این نقش درسیستم فعالیت می کنند"
            };
        }

        _db.Roles.Remove(role);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "نقش حذف گردید"
        };
    }

    public async Task<ResultDto<RoleDto>> GetByAsync(string name) {
        var role = await _db.Roles
            .FirstOrDefaultAsync(x => x.Name.Equals(name));
        if (role == null) {
            return new ResultDto<RoleDto>() {
                IsSuccess = false,
                Message = "نقشی با این نام یافت نشد",
                Data = null
            };
        }

        return new ResultDto<RoleDto> {
            Data = _mapper.Map<RoleDto>(role),
            IsSuccess = true,
        };
    }

    public async Task<ResultDto<RoleDto>> GetByAsync(int id) {
        var role = await _db.Roles
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (role == null) {
            return new ResultDto<RoleDto>() {
                IsSuccess = false,
                Message = "نقشی با این کد یافت نشد",
                Data = null
            };
        }

        return new ResultDto<RoleDto> {
            Data = _mapper.Map<RoleDto>(role),
            IsSuccess = true,
        };
    }

    public async Task<ResultDto<IEnumerable<RoleDto>>> GetAllAsync() {
        var roles = await _db.Roles
            .Include(x => x.Users)
            .ToListAsync();
        return new ResultDto<IEnumerable<RoleDto>>() {
            Data = _mapper.Map<IEnumerable<RoleDto>>(roles),
            IsSuccess = true,
        };
    }
}