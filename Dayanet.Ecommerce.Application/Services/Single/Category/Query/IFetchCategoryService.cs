using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Query;

public interface IFetchCategoryService
{
    Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync(string? filter,int? parentId);
}