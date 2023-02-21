using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public interface ILoginService {
    Task<ResultDto<AuthResultDto>> LoginAsync(LoginDto loginDto);
}