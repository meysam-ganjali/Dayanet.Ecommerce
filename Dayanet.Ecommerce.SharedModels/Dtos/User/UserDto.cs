using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;

namespace Dayanet.Ecommerce.SharedModels.Dtos.User;

public class UserDto {
    public long Id { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public string CellPhone { get; set; }
    public string? Email { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool? LockoutEnabled { get; set; } = false;
    public DateTime? LockoutEnd { get; set; }
    public DateTime? LastLoginDateTime { get; set; }
    public int RoleId { get; set; }
    public RoleDto Role { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<UserAddressDto> UserAddresses { get; set; }
    //public virtual ICollection<Cart> Carts { get; set; }
    //public virtual ICollection<Order> Orders { get; set; }
    //public virtual ICollection<Finance> Finances { get; set; }
    //public virtual ICollection<Favorit> Favorits { get; set; }
    //public virtual ICollection<Comment> Comments { get; set; }

}