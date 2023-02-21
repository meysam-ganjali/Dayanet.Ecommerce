using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.SharedModels;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Command;

public class RemoveSliderService : IRemoveSliderService {
    private readonly IDataBaseContext _db;
    private IHostingEnvironment _environment;

    public RemoveSliderService(IDataBaseContext db, IHostingEnvironment environment) {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        var slider = await _db.Sliders.FindAsync(id);
        if (slider == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "اسلایدر یافت نشد"
            };
        }
        string webRootPath = _environment.WebRootPath;
        var oldImagePath = Path.Combine(webRootPath, slider.ImagePath.TrimStart('\\'));
        DeleteFile.DeleteFileFromRoot(oldImagePath);
        _db.Sliders.Remove(slider);
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "اسلایدر حذف شد",
            IsSuccess = true
        };
    }
}