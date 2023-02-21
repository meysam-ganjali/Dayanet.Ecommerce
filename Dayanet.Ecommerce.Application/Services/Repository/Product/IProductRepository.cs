using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

namespace Dayanet.Ecommerce.Application.Services.Repository.Product;

public interface IProductRepository
{
    Task<ResultDto> AddToInventoryAsync(CreateInventoryDto inventoryDto);
}