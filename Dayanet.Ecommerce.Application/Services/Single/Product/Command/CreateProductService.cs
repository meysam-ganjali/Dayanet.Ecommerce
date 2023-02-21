using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Comman.FileTools;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;
using Microsoft.AspNetCore.Hosting;

namespace Dayanet.Ecommerce.Application.Services.Single.Product.Command;

public class CreateProductService : ICreateProductService {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public CreateProductService(IDataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<ResultDto> AddAsync(CreateProductDto productDto) {
        var product = _mapper.Map<Domain.Entities.Ecommerce.Product>(productDto);
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(productDto.Image, $@"assets\images\products\");
        product.ImageCoverPath = uploadedResult.FileNameAddress;

        try {

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = "محصول با موفقیت ثبت گردید"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }
}