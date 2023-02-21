using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Command;

public interface IUpdateCategoryService
{
    Task<ResultDto> UpdateAsync(UpdateCategoryDto category);
}