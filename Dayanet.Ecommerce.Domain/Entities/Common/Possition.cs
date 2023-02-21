namespace Dayanet.Ecommerce.Domain.Entities.Common;

public class Possition : BaseEntity {
    public string PossitionNameFA { get; set; }
    public string ProssitionNameEN { get; set; }
    public virtual ICollection<Slider> Sliders { get; set; }
    public virtual ICollection<Banner> Banners { get; set; }
}