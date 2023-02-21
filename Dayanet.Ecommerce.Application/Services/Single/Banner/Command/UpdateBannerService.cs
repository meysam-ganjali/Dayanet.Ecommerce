using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Command;

public class UpdateBannerService : IUpdateBannerService {
    private readonly IDataBaseContext _db;
    private IHostingEnvironment _environment;

    public UpdateBannerService(IDataBaseContext db, IHostingEnvironment environment) {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> UpdateAsync(UpdateBannerDto updateBannerDto) {
        var banner = await _db.Banners.FindAsync(updateBannerDto.Id);
        if (banner == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "بنر یافت نشد"
            };
        }

        if (updateBannerDto.Image != null) {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, banner.ImagePath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);

            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(updateBannerDto.Image, $@"assets\images\banner\");
            banner.ImagePath = uploadedResult.FileNameAddress;
        }

        banner.Title = updateBannerDto.Title;
        banner.Description = updateBannerDto.Description;
        banner.Link = updateBannerDto.Link;
        banner.PossitionId = updateBannerDto.PossitionId;
        banner.UpdateedDate = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto() {
            IsSuccess = true,
            Message = $"بنر {updateBannerDto.Title} با موفقیت بروزرسانی شد"
        };
    }
}