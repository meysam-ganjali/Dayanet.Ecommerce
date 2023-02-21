using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Command;

public interface IRemoveSliderService
{
    Task<ResultDto> RemoveAsync(int id);
}