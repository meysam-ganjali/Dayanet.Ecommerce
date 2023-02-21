using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Command;

public class UpdateSliderService : IUpdateSliderService {
    private readonly IDataBaseContext _db;
    private IHostingEnvironment _environment;

    public UpdateSliderService(IDataBaseContext db, IHostingEnvironment environment) {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> UpdateAsync(UpdateSliderDto updateSliderDto) {
        var slider = await _db.Sliders.FindAsync(updateSliderDto.Id);
        if (slider == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "اسلایدر یافت نشد"
            };
        }

        if (updateSliderDto.Image != null) {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, slider.ImagePath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);

            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(updateSliderDto.Image, $@"assets\images\slider\");
            slider.ImagePath = uploadedResult.FileNameAddress;
        }
        slider.UpdateedDate=DateTime.Now;
        slider.Title = updateSliderDto.Title;
        slider.Description = updateSliderDto.Description;
        slider.Link = updateSliderDto.Link;
        slider.PossitionId = updateSliderDto.PossitionId;
        await _db.SaveChangesAsync();
        return new ResultDto() {
            IsSuccess = true,
            Message = $"اسلایدر {updateSliderDto.Title} با موفقیت بروزرسانی شد"
        };
    }
}