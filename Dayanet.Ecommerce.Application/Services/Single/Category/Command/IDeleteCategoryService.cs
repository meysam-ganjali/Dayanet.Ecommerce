using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Command;

public interface IDeleteCategoryService
{
    Task<ResultDto> DeleteAsync(int cateId);
}