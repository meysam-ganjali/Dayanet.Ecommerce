using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Application.Services.Single.Slider.Command;
using Dayanet.Ecommerce.Application.Services.Single.Slider.Query;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.FASADE.Slider;

public class SliderFasade : ISliderFasade {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public SliderFasade(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    private ICreateSliderService _createSlider;
    public ICreateSliderService CreateSlider {
        get {
            return _createSlider = _createSlider ?? new CreateSliderService(_db, _mapper, _environment);
        }
    }
    private IFetchSliderService _fetchSlider;
    public IFetchSliderService FetchSlider {
        get {
            return _fetchSlider = _fetchSlider ?? new FetchSliderService(_db, _mapper);
        }
    }
    private IRemoveSliderService _removeSlider;
    public IRemoveSliderService RemoveSlider {
        get {
            return _removeSlider = _removeSlider ?? new RemoveSliderService(_db, _environment);
        }
    }
    private IUpdateSliderService _updateSlider;
    public IUpdateSliderService UpdateSlider {
        get {
            return _updateSlider = _updateSlider ?? new UpdateSliderService(_db, _environment);
        }
    }
}