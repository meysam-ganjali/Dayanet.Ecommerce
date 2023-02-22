using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

namespace Dayanet.Ecommerce.Application.Services.Repository.Product;

public interface IProductRepository
{
    Task<ResultDto> AddToInventoryAsync(CreateInventoryDto inventoryDto);
    Task<ResultDto<int>> AddAttribute(ProductAttributeDto attributeDto);//ResultDto<int> : int = Product Id
    Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAttributeForProductCategory(int categoryId);
    Task<ResultDto> AddProductGallaryAsync(CreateProductGallaryDto gallaries);
}
