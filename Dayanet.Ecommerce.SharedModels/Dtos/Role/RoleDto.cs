using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.SharedModels.Dtos.Role;

public class RoleDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsShow { get; set; }
    public List<UserDto> Users { get; set; }
}