using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;

namespace Dayanet.Ecommerce.Application.Services.Repository.Role;

public interface IRoleRepository {
    Task<ResultDto> AddAsync(CreateRoleDto role);
    Task<ResultDto> UpdateAsync(UpdateRoleDto role);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto<RoleDto>> GetByAsync(string name);
    Task<ResultDto<RoleDto>> GetByAsync(int id);
    Task<ResultDto<IEnumerable<RoleDto>>> GetAllAsync();
}