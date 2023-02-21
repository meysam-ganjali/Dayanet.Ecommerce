using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;

namespace Dayanet.Ecommerce.Application.Services.Single.Product.Query;

public interface IFetchProductService
{
   ResultDto<ProductForAdminDto> GetAll(string? searchKey,int Page = 1, int PageSize = 20);
}