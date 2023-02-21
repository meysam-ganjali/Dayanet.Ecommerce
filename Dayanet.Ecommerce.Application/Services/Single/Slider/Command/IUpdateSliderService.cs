using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Command;

public interface IUpdateSliderService
{
    Task<ResultDto> UpdateAsync(UpdateSliderDto updateSliderDto);
}