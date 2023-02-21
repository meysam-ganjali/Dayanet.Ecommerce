using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Application.Services.Single.Banner.Command;
using Dayanet.Ecommerce.Application.Services.Single.Banner.Query;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.FASADE.Banner;

public class BannerFasade : IBannerFasade {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public BannerFasade(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    private ICreateBannerService _createBanner;
    public ICreateBannerService CreateBanner {
        get {
            return _createBanner = _createBanner ?? new CreateBannerService(_db, _mapper, _environment);
        }
    }

    private IFetchBannerService _fetchBanner;
    public IFetchBannerService FetchBanner {
        get {
            return _fetchBanner = _fetchBanner ?? new FetchBannerService(_db, _mapper);
        }
    }

    private IRemoveBannerService _removeBanner;
    public IRemoveBannerService RemoveBanner {
        get {
            return _removeBanner = _removeBanner ?? new RemoveBannerService(_db, _environment);
        }
    }

    private IUpdateBannerService _updateBanner;
    public IUpdateBannerService UpdateBanner {
        get {
            return _updateBanner = _updateBanner ?? new UpdateBannerService(_db, _environment);
        }
    }
}