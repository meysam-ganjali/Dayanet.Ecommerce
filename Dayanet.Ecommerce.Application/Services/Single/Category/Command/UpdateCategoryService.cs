using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Command;

public class UpdateCategoryService : IUpdateCategoryService {
    private readonly IDataBaseContext _db;

    public UpdateCategoryService(IDataBaseContext db) {
        _db = db;
    }

    public async Task<ResultDto> UpdateAsync(UpdateCategoryDto category) {
        var categoryInDb = await _db.Categories.FindAsync(category.Id);
        if (categoryInDb == null) {
            return new ResultDto {
                Message = "دسته یافت نشد",
                IsSuccess = false,
            };
        }
        categoryInDb.Name = category.Name;
        categoryInDb.Description = category.Description;
        if (category.ParentCategoryId > 0 || category.ParentCategoryId !=null)
        {
            categoryInDb.ParentCategory = GetParent(category.ParentCategoryId);
        }
        categoryInDb.UpdateedDate=DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = $"دسته بندی {categoryInDb.Name} با موفقیت بروز شد"
        };
    }
    private Domain.Entities.Ecommerce.Category GetParent(int? ParentId) {
        return _db.Categories.Find(ParentId);
    }
}