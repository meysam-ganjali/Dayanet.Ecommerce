using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Repository.User;

public interface IActivityUserRepository
{
    Task<ResultDto> LockOnLockAsync(long id);
    Task<ResultDto> ActiveDeActiveAsync(long id);
    Task<ResultDto> ChangeRoleAsync(long UserId, int RoleId);
}