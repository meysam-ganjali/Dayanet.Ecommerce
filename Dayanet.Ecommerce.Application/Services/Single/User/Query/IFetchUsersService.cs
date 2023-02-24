using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Query;

public interface IFetchUsersService
{
    ResultDto<UserForAdmin> GetAllAsync(string?  filterUser, string? filter = null, int pageSize = 100, int pageNumber = 1);
}