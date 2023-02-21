using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Command;

public interface IUpdateBannerService
{
    Task<ResultDto> UpdateAsync(UpdateBannerDto updateBannerto);
}