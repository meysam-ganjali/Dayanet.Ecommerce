using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Possition;

namespace Dayanet.Ecommerce.Application.Services.Repository.Possition;

public interface IPossitionRepository {
    Task<ResultDto> CreateAsync(CreatePossitionDto createPossitionDto);
    Task<ResultDto> UpdateAsync(UpdatePossitionDto createPossitionDto);
    Task<IEnumerable<PossitionDto>> GetAllAsync();
    Task<ResultDto<PossitionDto>> GetByIdAsync(int id);
    Task<ResultDto> RemoveAsync(int id);
}