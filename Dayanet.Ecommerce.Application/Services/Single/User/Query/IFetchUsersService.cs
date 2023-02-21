using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Query;

public interface IFetchUsersService
{
    Task<ResultDto<IEnumerable<UserDto>>> GetAllAsync(string? filter = null, int pageSize = 100, int pageNumber = 1);
}