using Dayanet.Ecommerce.Application.Services.Single.Product.Command;
using Dayanet.Ecommerce.Application.Services.Single.Product.Query;

namespace Dayanet.Ecommerce.Application.FASADE.Product;

public interface IProductFasade {
    ICreateProductService CreateProduct { get; }
    IFetchProductService FetchProduct { get; }
    IFetchProductByIdService FetchProductById { get; }
}