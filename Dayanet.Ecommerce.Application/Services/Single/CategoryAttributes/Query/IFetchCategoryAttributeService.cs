using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Query;

public interface IFetchCategoryAttributeService
{
    Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAllAsync(string? Filter);
}