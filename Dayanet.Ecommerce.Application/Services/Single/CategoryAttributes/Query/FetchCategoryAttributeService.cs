using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Microsoft.EntityFrameworkCore;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Query;

public class FetchCategoryAttributeService : IFetchCategoryAttributeService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public FetchCategoryAttributeService(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAllAsync(string? filter) {
        var attrs = _db.CategoryAttributes
            .Include(x => x.Category)
            .ThenInclude(x => x.ParentCategory)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter)) {
            attrs = attrs.Where(x => x.AttributeName.Contains(filter) || x.Category.Name.Contains(filter))
                .AsQueryable();
        }

        return new ResultDto<IEnumerable<CategoryAttributeDto>> {
            Data = _mapper.Map<IEnumerable<CategoryAttributeDto>>(attrs),
            IsSuccess = true
        };
    }
}