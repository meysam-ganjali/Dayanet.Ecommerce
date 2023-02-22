using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

namespace Dayanet.Ecommerce.Application.Services.Repository.Product;

public interface IProductRepository
{
    Task<ResultDto> AddToInventoryAsync(CreateInventoryDto inventoryDto);
    Task<ResultDto<ResultAddAttribute>> AddAttribute(ProductAttributeDto attributeDto,int categoryId);
    Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAttributeForProductCategory(int categoryId);

}

public class ResultAddAttribute
{
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
}