

using Dayanet.Ecommerce.Application.Services.Single.Banner.Command;
using Dayanet.Ecommerce.Application.Services.Single.Banner.Query;

namespace Dayanet.Ecommerce.Application.FASADE.Banner;

public interface IBannerFasade
{
    ICreateBannerService CreateBanner { get; }
    IFetchBannerService FetchBanner { get; }
    IRemoveBannerService RemoveBanner { get; }
    IUpdateBannerService UpdateBanner { get; }
}