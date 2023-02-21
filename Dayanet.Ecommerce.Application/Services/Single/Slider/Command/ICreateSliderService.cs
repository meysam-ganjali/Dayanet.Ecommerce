using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Command;

public interface ICreateSliderService
{
    Task<ResultDto>CreateAsync(CreateSliderDto createSliderDto);
}