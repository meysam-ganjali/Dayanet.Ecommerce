using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Query;

public interface IFetchCategoryAttributeServiceById
{
    Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAsync(int CatId);
}