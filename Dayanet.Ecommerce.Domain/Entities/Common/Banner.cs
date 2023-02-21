namespace Dayanet.Ecommerce.Domain.Entities.Common;

public class Banner : BaseEntity {
    public string? Title { get; set; }
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public int PossitionId { get; set; }
    public virtual Possition Possition { get; set; }
}