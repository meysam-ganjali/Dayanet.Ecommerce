using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public interface IDeleteUserService
{
    Task<ResultDto> RemoveAsync(long id);
}