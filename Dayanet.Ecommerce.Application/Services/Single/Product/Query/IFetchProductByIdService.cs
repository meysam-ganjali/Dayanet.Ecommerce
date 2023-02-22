using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;

namespace Dayanet.Ecommerce.Application.Services.Single.Product.Query;

public interface IFetchProductByIdService
{
    Task<ResultDto<ProductDetialeDto>> GetByIdAsync(int id);
}