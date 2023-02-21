using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;

public class UpdateCategoryAttributeService: IUpdateCategoryAttributeService
{
    private readonly IDataBaseContext _db;

    public UpdateCategoryAttributeService(IDataBaseContext db)
    {
        _db = db;
    }
    public async Task<ResultDto> UpdateAsync(UpdateCategoryAttributeDto updateCategoryAttributeDto)
    {
        var attribute = await _db.CategoryAttributes.FindAsync(updateCategoryAttributeDto.Id);
        if (attribute == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "مشخصه ای با این پارامتر یافت نشد"
            };
        }

        attribute.AttributeName = updateCategoryAttributeDto.AttributeName;
        if (updateCategoryAttributeDto.CategoryId > 0 || updateCategoryAttributeDto.CategoryId != null)
        {
             attribute.CategoryId = updateCategoryAttributeDto.CategoryId;
        }
        attribute.UpdateedDate = DateTime.Now;

        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = "مشخصه فوق با موفقیت بروزرسانی شد"
        };
    }
}