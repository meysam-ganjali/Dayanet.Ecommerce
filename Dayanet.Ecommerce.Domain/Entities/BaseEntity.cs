namespace Dayanet.Ecommerce.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
}
public class BaseEntity<TPrimaryKey> {
    public TPrimaryKey Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
}

public class BaseEntity<TPrimaryKey,TActive>
{
    public TPrimaryKey Id { get; set; }
    public TActive IsActive { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdateedDate { get; set; }
}