using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Query;

public class FetchBannerService : IFetchBannerService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchBannerService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<IEnumerable<BannerDto>>> GetAllAsync() {
        var sliders = await _db.Banners.Include(x => x.Possition).ToListAsync();
        return new ResultDto<IEnumerable<BannerDto>>() {
            Data = _mapper.Map<IEnumerable<BannerDto>>(sliders),
            IsSuccess = true
        };
    }
}