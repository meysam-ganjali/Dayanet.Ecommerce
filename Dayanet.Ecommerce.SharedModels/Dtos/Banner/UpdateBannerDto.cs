using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Microsoft.AspNetCore.Http;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Banner;

public class UpdateBannerDto {
    public int Id { get; set; }
    public string? Title { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public int PossitionId { get; set; }
    public virtual PossitionDto Possition { get; set; }
}