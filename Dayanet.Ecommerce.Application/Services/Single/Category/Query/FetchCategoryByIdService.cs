using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.Category.Query;

public class FetchCategoryByIdService : IFetchCategoryByIdService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchCategoryByIdService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<CategoryDto>> GetAsync(int id) {
        var category = await _db.Categories
            .Include(x => x.SubCategories)
            .Include(x => x.ParentCategory)
            .Include(x=>x.CategoryAttributes)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (category == null) {
            return new ResultDto<CategoryDto> {
                Data = null,
                IsSuccess = false,
                Message = "دسته یافت نشد"
            };
        }

        return new ResultDto<CategoryDto>() {
            Data = _mapper.Map<CategoryDto>(category),
            IsSuccess = true,
        };
    }
}