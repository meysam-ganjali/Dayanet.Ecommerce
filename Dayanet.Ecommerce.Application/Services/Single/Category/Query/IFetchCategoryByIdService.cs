using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Query;

public interface IFetchCategoryByIdService
{
    Task<ResultDto<CategoryDto>> GetAsync(int id);
}