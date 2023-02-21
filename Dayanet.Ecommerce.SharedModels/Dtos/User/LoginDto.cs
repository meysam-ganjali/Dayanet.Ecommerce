using System.ComponentModel.DataAnnotations;

namespace Dayanet.Ecommerce.SharedModels.Dtos.User;

public class LoginDto {
    [Required(ErrorMessage = "نام کاربری را وارد کنید")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
    [MinLength(6, ErrorMessage = "کلمه عبور باید حداقل 6 کاراکتر باشد")]
    public string Password { get; set; }

    public bool IsMemberMe { get; set; } = true;
}