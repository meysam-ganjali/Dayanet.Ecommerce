using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Query;

public class FetchSliderService : IFetchSliderService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchSliderService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<IEnumerable<SliderDto>>> GetAllAsync() {
        var sliders = await _db.Sliders.Include(x => x.Possition).ToListAsync();
        return new ResultDto<IEnumerable<SliderDto>>() {
            Data = _mapper.Map<IEnumerable<SliderDto>>(sliders),
            IsSuccess = true
        };
    }
}