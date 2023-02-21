using System.ComponentModel.DataAnnotations.Schema;

namespace Dayanet.Ecommerce.SharedModels.Dtos.User;

public class UserAddressDto
{
    public string Address { get; set; }
    public long UserId { get; set; }
    public UserDto User { get; set; }
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; } 
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    //public virtual ICollection<Order> Orders { get; set; }
}
public class CreateUserAddressDto {
    public string Address { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsShow { get; set; }
    //public virtual ICollection<Order> Orders { get; set; }
}
public class UpdateUserAddressDto {
    public string Address { get; set; }
    public long UserId { get; set; }
    public long Id { get; set; }
    public DateTime? UpdateedDate { get; set; }
    public bool IsShow { get; set; }
    //public virtual ICollection<Order> Orders { get; set; }
}