using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.SharedModels;

namespace Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;

public class DeleteCategoruAttributeService : IDeleteCategoruAttributeService
{
    private readonly IDataBaseContext _db;

    public DeleteCategoruAttributeService(IDataBaseContext db)
    {
        _db = db;
    }
    public async Task<ResultDto> RemoveAsync(int id)
    {
        var attribute = await _db.CategoryAttributes.FindAsync(id);
        if (attribute == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "مشخصه ای با این پارامتر یافت نشد"
            };
        }

        _db.CategoryAttributes.Remove(attribute);
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = $"مشخصه {attribute.AttributeName} از سیستم حذف گردید"
        };
    }
}