using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Banner.Command;

public class CreateBannerService : ICreateBannerService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public CreateBannerService(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<ResultDto> CreateAsync(CreateBannerDto createBannerDto) {
        var banner = _mapper.Map<Domain.Entities.Common.Banner>(createBannerDto);
        try {
            
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(createBannerDto.Image, $@"assets\images\banner\");
            banner.ImagePath = uploadedResult.FileNameAddress;
            await _db.Banners.AddAsync(banner);
            await _db.SaveChangesAsync();

            return new ResultDto {
                IsSuccess = true,
                Message = "بنر ثبت شد"
            };
        } catch (Exception e) {
            return new ResultDto() {
                IsSuccess = false,
                Message = e.Message,
            };
        }
    }
}