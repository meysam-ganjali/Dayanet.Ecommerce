using Dayanet.Ecommerce.SharedModels.Dtos.Possition;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Slider;

public class SliderDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public int PossitionId { get; set; }
    public  PossitionDto Possition { get; set; }
}