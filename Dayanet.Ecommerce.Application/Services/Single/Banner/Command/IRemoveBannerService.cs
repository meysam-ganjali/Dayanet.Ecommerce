using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Command;

public interface IRemoveBannerService
{
    Task<ResultDto> RemoveAsync(int id);
}