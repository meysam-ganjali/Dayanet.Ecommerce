using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;

public class CreateCategoryAttributeService:ICreateCategoryAttributeService
{
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public CreateCategoryAttributeService(IDataBaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> AddAsync(CreateCategoryAttributeDto categoryAttributeDto)
    {
        var attrEntity = _mapper.Map<CategoryAttribute>(categoryAttributeDto);
        if (string.IsNullOrWhiteSpace(categoryAttributeDto.ToString()))
        {
            return new ResultDto()
            {
                IsSuccess = false,
                Message = "عنوان مشخصه وارد نشده است"
            };
        }
        if (categoryAttributeDto.CategoryId == null || categoryAttributeDto.CategoryId <= 0) {
            return new ResultDto() {
                IsSuccess = false,
                Message = "دسته مورد نظر معتبر نیست"
            };
        }
        await _db.CategoryAttributes.AddAsync(attrEntity);
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            Message = $"مشخصه {categoryAttributeDto.AttributeName} در سیستم ثبت گردید",
            IsSuccess = true
        };
    }
}