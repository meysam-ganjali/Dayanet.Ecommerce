using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Command;

public class CreateCategoryService:ICreateCategoryService
{
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public CreateCategoryService(IDataBaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> AddAsync(CreateCategoryDto category)
    {
        var categoryEntity = _mapper.Map<Domain.Entities.Ecommerce.Category>(category);
        if (string.IsNullOrEmpty(category.Name)) {
            return new ResultDto() {
                IsSuccess = false,
                Message = "نام دسته بندی را وارد نمایید",
            };
        }

        categoryEntity.ParentCategory = GetParent(category.ParentCategoryId);
        await _db.Categories.AddAsync(categoryEntity);
       await _db.SaveChangesAsync();
        return new ResultDto() {
            IsSuccess = true,
            Message = "دسته بندی با موفقیت اضافه شد",
        };
    }

    private Domain.Entities.Ecommerce.Category GetParent(int? ParentId) {
        return  _db.Categories.Find(ParentId);
    }
}
