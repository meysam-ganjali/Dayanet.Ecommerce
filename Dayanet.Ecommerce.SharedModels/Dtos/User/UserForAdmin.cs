using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;

namespace Dayanet.Ecommerce.SharedModels.Dtos.User;

public class UserForAdmin
{
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public List<UserDto> UserDtos { get; set; }
}