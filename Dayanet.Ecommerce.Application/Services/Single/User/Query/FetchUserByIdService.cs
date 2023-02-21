using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Query;

public class FetchUserByIdService : IFetchUserByIdService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchUserByIdService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<UserDto>> GetAsyncById(long id) {
        var user = await _db.Users
            .Include(x => x.Role)
            .Include(x => x.UserAddresses)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (user == null) {
            return new ResultDto<UserDto> {
                Data = null,
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }

        return new ResultDto<UserDto> {
            Data = _mapper.Map<UserDto>(user),
            IsSuccess = true
        };
    }
}