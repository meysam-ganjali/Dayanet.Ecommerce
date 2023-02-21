using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Command;

public interface ICreateBannerService {
    Task<ResultDto> CreateAsync(CreateBannerDto createBannerDto);
}