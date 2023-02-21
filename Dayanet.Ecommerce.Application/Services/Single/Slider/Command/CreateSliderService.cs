using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Slider.Command;

public class CreateSliderService : ICreateSliderService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public CreateSliderService(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<ResultDto> CreateAsync(CreateSliderDto createSliderDto) {
        var slider = _mapper.Map<Domain.Entities.Common.Slider>(createSliderDto);
        try {
            
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(createSliderDto.Image, $@"assets\images\slider\");
            slider.ImagePath = uploadedResult.FileNameAddress;
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();

            return new ResultDto {
                IsSuccess = true,
                Message = "اسلایدر ثبت شد"
            };
        } catch (Exception e) {
            return new ResultDto() {
                IsSuccess = false,
                Message = e.Message,
            };
        }
    }
}