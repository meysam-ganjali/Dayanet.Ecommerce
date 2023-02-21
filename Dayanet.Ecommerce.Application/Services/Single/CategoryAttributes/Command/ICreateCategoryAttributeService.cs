using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;

public interface ICreateCategoryAttributeService
{
    Task<ResultDto> AddAsync(CreateCategoryAttributeDto categoryAttributeDto);
}