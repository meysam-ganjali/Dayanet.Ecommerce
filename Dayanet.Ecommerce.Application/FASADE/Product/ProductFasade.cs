using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Application.Services.Single.Product.Command;
using Dayanet.Ecommerce.Application.Services.Single.Product.Query;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.FASADE.Product;

public class ProductFasade : IProductFasade {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public ProductFasade(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    private ICreateProductService _createProduct;
    public ICreateProductService CreateProduct {
        get {
            return _createProduct = _createProduct ?? new CreateProductService(_db, _mapper, _environment);
        }
    }
    private IFetchProductService _fetchProduct;
    public IFetchProductService FetchProduct {
        get {
            return _fetchProduct = _fetchProduct ?? new FetchProductService(_db);
        }
    }
}