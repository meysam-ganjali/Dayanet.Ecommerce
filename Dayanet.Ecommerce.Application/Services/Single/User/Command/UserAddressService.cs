using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Domain.Entities.Auth;
using Dayanet.Ecommerce.SharedModels;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.Application.Services.Single.User.Command;

public class UserAddressService : IUserAddressService {
    private readonly IDataBaseContext db;
    private IMapper mapper;

    public UserAddressService(IDataBaseContext db, IMapper mapper) {
        this.db = db;
        this.mapper = mapper;
    }

    public async Task<ResultDto> CreateAsync(CreateUserAddressDto userAddressDto)
    {
        var userAddress = this.mapper.Map<UserAddress>(userAddressDto);
        await this.db.UserAddresses.AddAsync(userAddress);
        await this.db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = "آدرس جدید ذخیره شد"
        };
    }
}