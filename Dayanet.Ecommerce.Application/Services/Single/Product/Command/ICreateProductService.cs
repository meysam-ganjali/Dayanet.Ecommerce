using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;

namespace Dayanet.Ecommerce.Application.Services.Single.Product.Command;

public interface ICreateProductService
{
    Task<ResultDto> AddAsync(CreateProductDto productDto);
}