using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Command;

public class DeleteCategoryService : IDeleteCategoryService {
    private readonly IDataBaseContext _db;
    public DeleteCategoryService(IDataBaseContext db) {
        _db = db;

    }
    public async Task<ResultDto> DeleteAsync(int cateId)
    {
        var category = await _db.Categories
            .Include(x => x.SubCategories)
            .FirstOrDefaultAsync(x => x.Id == cateId);
        if (category == null) {
            return new ResultDto {
                Message = "دسته یافت نشد",
                IsSuccess = false
            };
        }

        if (category.SubCategories.Count > 0)
        {
            foreach (var item in category.SubCategories)
            {
                _db.Categories.Remove(item);
            }
        }
        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = $"دسته بندی {category.Name} با موفقیت از سیستم حذف گردید"
        };
    }
}