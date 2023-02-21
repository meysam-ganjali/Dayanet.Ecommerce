using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dayanet.Ecommerce.Domain.Entities.ProductCommon;
using Dayanet.Ecommerce.Domain.Entities.ShoopingCart;
using Dayanet.Ecommerce.Domain.Entities.ShoppingOrder;

namespace Dayanet.Ecommerce.Domain.Entities.Auth;

public class User:BaseEntity<long,bool>{
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public string CellPhone { get; set; }
    public string? Email { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool? LockoutEnabled { get; set; } = false;
    public DateTime? LockoutEnd { get; set; }
    public DateTime? LastLoginDateTime { get; set; }
    //Reration
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }

    public virtual ICollection<Cart> Carts { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Finance> Finances { get; set; }
    public virtual ICollection<Favorit> Favorits { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<UserAddress> UserAddresses { get; set; }
}