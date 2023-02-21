using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;

public interface IUpdateCategoryAttributeService
{
    Task<ResultDto> UpdateAsync(UpdateCategoryAttributeDto updateCategoryAttributeDto);
}