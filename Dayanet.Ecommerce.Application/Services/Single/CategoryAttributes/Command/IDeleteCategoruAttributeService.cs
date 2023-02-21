using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;

public interface IDeleteCategoruAttributeService
{
    Task<ResultDto> RemoveAsync(int id);
}