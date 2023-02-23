using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.Domain.Entities.FinanecCost;

public class Cost
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int CostTypeId { get; set; }
    [ForeignKey("CostTypeId")]
    public virtual CostType CostType { get; set; }
}

public class CostType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Cost> Costs { get; set; }
}