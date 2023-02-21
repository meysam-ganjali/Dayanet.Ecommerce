using Dayanet.Ecommerce.Application.Services.Single.Slider.Command;
using Dayanet.Ecommerce.Application.Services.Single.Slider.Query;

namespace Dayanet.Ecommerce.Application.FASADE.Slider;

public interface ISliderFasade
{
    ICreateSliderService CreateSlider { get; }
    IFetchSliderService FetchSlider { get; }
    IRemoveSliderService RemoveSlider { get; }
    IUpdateSliderService UpdateSlider { get; }
}