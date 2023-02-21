using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
}