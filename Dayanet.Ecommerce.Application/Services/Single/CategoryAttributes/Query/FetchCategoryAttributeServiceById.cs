using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Query;

public class FetchCategoryAttributeServiceById : IFetchCategoryAttributeServiceById {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchCategoryAttributeServiceById(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }
    public async Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAsync(int CatId) {
        var result = await _db.CategoryAttributes
            .Where(x => x.CategoryId == CatId)
            .ToListAsync();
        if (result == null) {
            return new ResultDto<IEnumerable<CategoryAttributeDto>> {
                Data = null,
                IsSuccess = false,
                Message = "مشخصه ای یافت نشد"
            };
        }

        return new ResultDto<IEnumerable<CategoryAttributeDto>> {
            Data = _mapper.Map<IEnumerable<CategoryAttributeDto>>(result),
            IsSuccess = true
        };
    }
}