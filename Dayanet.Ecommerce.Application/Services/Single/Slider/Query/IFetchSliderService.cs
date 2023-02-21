using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Query;

public interface IFetchSliderService
{
    Task<ResultDto<IEnumerable<SliderDto>>> GetAllAsync();
}