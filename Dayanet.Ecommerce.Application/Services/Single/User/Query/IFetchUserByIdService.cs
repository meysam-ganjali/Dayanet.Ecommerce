using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Query;

public interface IFetchUserByIdService {
    Task<ResultDto<UserDto>> GetAsyncById(long id);
}