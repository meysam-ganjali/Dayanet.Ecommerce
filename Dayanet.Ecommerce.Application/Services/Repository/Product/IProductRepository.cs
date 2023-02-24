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
    Task<ResultDto> RemoveFromGallery(int gallaryId);
    Task<ResultDto> RemoveFromProductAttribute(int productAttrId);
    Task<ResultDto> UpdateProductAttribute(int productAttrId,string attrValue, string? colorHex);

    Task<ResultDto> ActivDeActivComment(int pId);
    Task<ResultDto> ActivDeActivIsShow(int pId);
    Task<ResultDto> ActivDeActivShowInHomePage(int pId);
    Task<ResultDto> ActivDeActivIsSotial(int pId);

}
