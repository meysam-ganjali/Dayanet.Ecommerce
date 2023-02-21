using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Query;

public interface IFetchBannerService
{
    Task<ResultDto<IEnumerable<BannerDto>>> GetAllAsync();
}