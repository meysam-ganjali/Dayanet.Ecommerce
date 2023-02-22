using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.Help;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;
using Dayanet.Ecommerce.SharedModels.Dtos.ProductGallery;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Product.Query;

public class FetchProductService : IFetchProductService {
    private readonly IDataBaseContext _db;

    public FetchProductService(IDataBaseContext db) {
        _db = db;
    }

    public ResultDto<ProductForAdminDto> GetAll(string? searchKey, int Page = 1, int PageSize = 20) {
        int rowCount = 0;
        var products = _db.Products
            .Include(p => p.Category)
            .ThenInclude(x => x.CategoryAttributes)
            .Include(x => x.ProductAttributes)
            .ThenInclude(x => x.AttributeValues)
            .Include(x => x.ProductGalleries)
            .Include(x => x.Inventory)

            .ToPaged(Page, PageSize, out rowCount).AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchKey)) {
            products = products.Where(x => x.Name.Contains(searchKey)).AsQueryable();
        }

        var productMappToDto = products.Select(p => new ProductDto {
            CategoryName = p.Category.Name,
            Name = p.Name,
            AllowCustomerComment = p.AllowCustomerComment,
            CategoryId = p.Category.Id,
            CreatedDate = p.CreatedDate,
            FullDescription = p.FullDescription,
            Height = p.Height,
            Id = p.Id,
            Price = p.Price,
            IsSotialProduct = p.IsSotialProduct,
            Weight = p.Weight,
            IsShow = p.IsShow,
            ImageCoverPath = p.ImageCoverPath,
            Length = p.Length,
            Rate = p.Rate,
            ShortDescription = p.ShortDescription,
            ShowCount = p.ShowCount,
            ShowOnHomepage = p.ShowOnHomepage,
            UpdateedDate = p.UpdateedDate,
            Width = p.Width,
            ProductCount = p.Inventory.ProductCount,
        }).ToList();
        return new ResultDto<ProductForAdminDto> {
            Data = new ProductForAdminDto() {
                Products = productMappToDto,
                CurrentPage = Page,
                PageSize = PageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
        };
    }
}