using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Query;

public class FetchCategoryService:IFetchCategoryService
{
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchCategoryService(IDataBaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync(string? filter, int? parentId)
    {
        var categories = _db.Categories
            .Include(x => x.SubCategories)
            .Include(x => x.ParentCategory)
            .Include(x => x.CategoryAttributes)
            .Where(x=>x.ParentCategoryId == null)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
        {
            categories = categories.Where(x => x.Name.Contains(filter)).AsQueryable();
        }

        if (parentId > 0 || parentId != null)
        {
            var childs = await _db.Categories
                .Include(x => x.SubCategories)
                .Include(x => x.ParentCategory)
                .Include(x => x.CategoryAttributes)
                .Where(x => x.ParentCategoryId == parentId)
                .ToListAsync();
            return new ResultDto<IEnumerable<CategoryDto>>
            {
                IsSuccess = true,
                Data = _mapper.Map<IEnumerable<CategoryDto>>(childs)
            };
        }

        var catForReturn = await _db.Categories.ToListAsync();
        return new ResultDto<IEnumerable<CategoryDto>>
        {
            Data = _mapper.Map<IEnumerable<CategoryDto>>(catForReturn),
            IsSuccess = true
        };
    }
}