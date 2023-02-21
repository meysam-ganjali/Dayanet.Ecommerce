using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.SharedModels;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Command;

public class RemoveBannerService : IRemoveBannerService {
    private readonly IDataBaseContext _db;
    private IHostingEnvironment _environment;

    public RemoveBannerService(IDataBaseContext db, IHostingEnvironment environment) {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        var banner = await _db.Banners.FindAsync(id);
        if (banner == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "بنر یافت نشد"
            };
        }
        string webRootPath = _environment.WebRootPath;
        var oldImagePath = Path.Combine(webRootPath, banner.ImagePath.TrimStart('\\'));
        DeleteFile.DeleteFileFromRoot(oldImagePath);
        _db.Banners.Remove(banner);
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "بنر حذف شد",
            IsSuccess = true
        };
    }
}