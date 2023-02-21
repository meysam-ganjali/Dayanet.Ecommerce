using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
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

    public async Task<ResultDto<IEnumerable<UserDto>>> GetAllAsync(string? filter = null, int pageSize = 1, int pageNumber = 1) {
       // 
        var users = _db.Users
            .Include(x => x.Role)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter)) {
            users = users.Where(x =>
                x.FullName.Contains(filter) || x.CellPhone.Contains(filter) || x.Email.Contains(filter)).AsQueryable();
        }
        var ConverToList = await users.ToListAsync();
        var mappUsersDto = _mapper.Map<IEnumerable<UserDto>>(ConverToList);
        mappUsersDto.FirstOrDefault().TotalRow = users.Count();
        return new ResultDto<IEnumerable<UserDto>>()
        {
            Data = mappUsersDto,
            IsSuccess = true
        };
    }
}