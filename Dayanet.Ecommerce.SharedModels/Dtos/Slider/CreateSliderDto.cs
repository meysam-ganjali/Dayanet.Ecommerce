using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Microsoft.AspNetCore.Http;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Slider;

public class CreateSliderDto
{
    public string? Title { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public IFormFile? Image { get; set; }
    public int PossitionId { get; set; }
    public  PossitionDto Possition { get; set; }
}