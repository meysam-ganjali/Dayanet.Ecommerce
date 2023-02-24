using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.Help;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;
using Dayanet.Ecommerce.SharedModels.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Dayanet.Ecommerce.Application.Services.Single.User.Query;

public class FetchUsersService : IFetchUsersService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchUsersService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public ResultDto<UserForAdmin> GetAllAsync(string? filterUser, string? filter = null, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        var users = _db.Users
            .Include(x => x.Role)
            .ToPaged(pageNumber, pageSize, out rowCount).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter)) {
            users = users.Where(x =>
                x.FullName.Contains(filter) || x.CellPhone.Contains(filter) || x.Email.Contains(filter)).AsQueryable();
        }

        if (!string.IsNullOrWhiteSpace(filterUser)) {
            switch (filterUser) {
                case "Lock-users": {
                        users = users.Where(x => x.LockoutEnabled == true);
                        break;
                    }
                case "deactive-users": {
                        users = users.Where(x => x.IsActive == false);
                        break;
                    }
                case "confirm-email": {
                        users = users.Where(x => x.EmailConfirmed == false);
                        break;
                    }
                case "confirm-phone": {
                        users = users.Where(x => x.PhoneNumberConfirmed == false);
                        break;
                    }
            }
        }

        var mappToDto =  users.Select(x => new UserDto {
            CellPhone = x.CellPhone,
            CreatedDate = x.CreatedDate,
            Email = x.Email,
            EmailConfirmed = x.EmailConfirmed,
            FullName = x.FullName,
            Id = x.Id,
            IsActive = x.IsActive,
            LastLoginDateTime = x.LastLoginDateTime,
            LockoutEnabled = x.LockoutEnabled,
            LockoutEnd = x.LockoutEnd,
            PhoneNumberConfirmed = x.PhoneNumberConfirmed,
            RoleId = x.RoleId,
            Role = new RoleDto
            {
                Id = x.Role.Id,
                IsShow = x.Role.IsShow, 
                Name = x.Role.Name
            }
        }).ToList();
        return new ResultDto<UserForAdmin> {
            Data = new UserForAdmin() {
                UserDtos = mappToDto,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
        };
    }
}