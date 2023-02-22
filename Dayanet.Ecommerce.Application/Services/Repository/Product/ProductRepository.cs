using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;

namespace Dayanet.Ecommerce.Application.Services.Repository.Product;

public class ProductRepository : IProductRepository
{
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public ProductRepository(IDataBaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<ResultDto> AddToInventoryAsync(CreateInventoryDto inventoryDto)
    {
        var productInInventory = await _db.Inventories
            .Include(p=>p.Product)
            .FirstOrDefaultAsync(x => x.ProductId == inventoryDto.ProductId);
        if (productInInventory == null)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDto);
            await _db.Inventories.AddAsync(inventory);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"محصول با تعداد {inventory.ProductCount} در انبار با شناسه {inventory.SKU} ثبت گردید"
            };
        } else {
            productInInventory.ProductCount += inventoryDto.ProductCount;
            productInInventory.UpdateedDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = $" به محصول {productInInventory.Product.Name}  تعداد {inventoryDto.ProductCount} در انبار اضافه گردید"
            };
        }
    }

    public async Task<ResultDto<ResultAddAttribute>> AddAttribute(ProductAttributeDto attributeDto,int categoryId)
    {
        ProductAttribute productAttribute = new ProductAttribute
        {
            IsShow = attributeDto.IsShow,
            ProductId = attributeDto.ProductId,
            CategoryAttributeId = attributeDto.CategoryAttributeId
        };
        await _db.ProductAttributes.AddAsync(productAttribute);
        await _db.SaveChangesAsync();
        AttributeValue attributeValue = new AttributeValue
        {
            ColorHex = attributeDto.ColorHex,
            Value = attributeDto.Value,
            ProductAttributeId = productAttribute.Id
        };
        await _db.AttributeValues.AddAsync(attributeValue);
        await _db.SaveChangesAsync();
        return new ResultDto<ResultAddAttribute>
        {
            Data = new ResultAddAttribute
            {
                ProductId = productAttribute.ProductId,
                CategoryId = categoryId
            },
            IsSuccess = true,
            Message = "مشخصه ثبت شد"
        };
    }

    public async Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAttributeForProductCategory(int categoryId)
    {
        //var attribute = await _db.CategoryAttributes
        //    .Include(x => x.Category)
        //    .ThenInclude(x => x.Products)
        //    .Where(x => x.CategoryId == categoryId).ToListAsync();
        var attribute = await _db.CategoryAttributes
            .Include(x => x.Category)
            .ThenInclude(x => x.Products)
            .Where(x => x.CategoryId == categoryId).ToListAsync();
        if (attribute == null)
        {
            return new ResultDto<IEnumerable<CategoryAttributeDto>>
            {
                Data = null,
                IsSuccess = false,
                Message = "مشخصاتی یافت نشد"
            };
        }

        return new ResultDto<IEnumerable<CategoryAttributeDto>>
        {
            Data = attribute.Select(x => new CategoryAttributeDto
            {
                AttributeName = x.AttributeName,
                Id=x.Id
            }),
            IsSuccess = true,
        };
    }
}