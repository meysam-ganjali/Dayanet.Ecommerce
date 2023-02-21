using System.ComponentModel.DataAnnotations;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;

namespace Dayanet.Ecommerce.SharedModels.Dtos.User;

public class CreateUserDto {
    [Required(ErrorMessage = "نام خود را وارد کنید")]
    public string FullName { get; set; }



    [Required(ErrorMessage = "تلفن همراه خود را وارد کنید")]
    [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 11 حرف داشته باشد", MinimumLength = 11)]
    public string CellPhone { get; set; }



    [Required(ErrorMessage = "ایمیل خود را وارد نکرده اید")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "کلمه عبور خود را وارد کنید")]
    [StringLength(100, ErrorMessage = "کلمه عبور باید حداقل 6 حرف داشته باشد", MinimumLength = 6)]
    public string PasswordHash { get; set; }



    [Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید")]

    public string ConfirmPassword { get; set; }




    public bool PhoneNumberConfirmed { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool? LockoutEnabled { get; set; } = false;
    public DateTime? LockoutEnd { get; set; }
    public DateTime? LastLoginDateTime { get; set; }
    public int RoleId { get; set; }

}