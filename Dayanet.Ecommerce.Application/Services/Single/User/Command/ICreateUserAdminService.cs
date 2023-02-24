using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public interface ICreateUserAdminService
{
    Task<ResultDto> CreateUserAdminAsync(CreateUserDto userDto);
}