using AutoMapper;
using Dayanet.Ecommerce.Domain.Entities.Auth;
using Dayanet.Ecommerce.Domain.Entities.Common;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Get;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Dayanet.Ecommerce.SharedModels.Dtos.User;

namespace Dayanet.Ecommerce.ModelMapper.MappConfig;

public class MappingProfile {
    public static MapperConfiguration RegisterMaps() {
        var mappingConfig = new MapperConfiguration(config => {

            #region Category Config
            /***************************    Category    ********************************/
            config.CreateMap<Category, CategoryDto>()
                .ForMember(p => p.SubCategories,
                    p => p.MapFrom(q => q.SubCategories))
                .ForMember(p => p.ParentCategory,
                    p => p.MapFrom(q => q.ParentCategory))
                .ForMember(p => p.CategoryAttributes,
                    p => p.MapFrom(q => q.CategoryAttributes));
            config.CreateMap<CategoryDto, Category>()
                .ForMember(p => p.SubCategories,
                    p => p.MapFrom(q => q.SubCategories))
                .ForMember(p => p.ParentCategory,
                    p => p.MapFrom(q => q.ParentCategory))
                .ForMember(p => p.CategoryAttributes,
                    p => p.MapFrom(q => q.CategoryAttributes));
            config.CreateMap<CreateCategoryDto, Category>().ReverseMap();
            config.CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            /***************************    Category    ********************************/
            #endregion

            #region Category Attribute Config

            /***************************    Category Attribute    ********************************/
            config.CreateMap<CategoryAttribute, CategoryAttributeDto>()
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category));


            config.CreateMap<CategoryAttributeDto, CategoryAttribute>()
                .ForMember(p => p.Category,
                    p => p.MapFrom(q => q.Category));

            config.CreateMap<CreateCategoryAttributeDto, CategoryAttribute>().ReverseMap();
            config.CreateMap<UpdateCategoryAttributeDto, CategoryAttribute>().ReverseMap();

            /***************************    Category Attribute    ********************************/

            #endregion

            #region Slider Config

            /***************************    Category    ********************************/
            config.CreateMap<Slider, SliderDto>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));


            config.CreateMap<SliderDto, Slider>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));


            config.CreateMap<CreateSliderDto, Slider>().ForMember(p => p.Possition,
                p => p.MapFrom(q => q.Possition));
            config.CreateMap<Slider, CreateSliderDto>().ForMember(p => p.Possition,
                p => p.MapFrom(q => q.Possition));


            config.CreateMap<UpdateSliderDto, Slider>().ReverseMap();

            #endregion

            #region Possition Config
            config.CreateMap<PossitionDto, Possition>().ReverseMap();
            config.CreateMap<CreatePossitionDto, Possition>().ReverseMap();
            config.CreateMap<UpdatePossitionDto, Possition>().ReverseMap();
            #endregion

            #region Banner Config

            config.CreateMap<Banner, BannerDto>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));


            config.CreateMap<BannerDto, Banner>()
                .ForMember(p => p.Possition,
                    p => p.MapFrom(q => q.Possition));


            config.CreateMap<CreateBannerDto, Banner>().ForMember(p => p.Possition,
                p => p.MapFrom(q => q.Possition));
            config.CreateMap<Banner, CreateBannerDto>().ForMember(p => p.Possition,
                p => p.MapFrom(q => q.Possition));


            config.CreateMap<UpdateBannerDto, Banner>().ReverseMap();

            #endregion

            #region Role Config

            config.CreateMap<Role, RoleDto>()
                .ForMember(p => p.Users,
                    p => p.MapFrom(q => q.Users));
            config.CreateMap<RoleDto, Role>()
                .ForMember(p => p.Users,
                    p => p.MapFrom(q => q.Users));

            config.CreateMap<Role, CreateRoleDto>().ReverseMap();
            config.CreateMap<Role, UpdateRoleDto>().ReverseMap();

            #endregion

            #region User Config

            config.CreateMap<UserDto, User>()
                .ForMember(p => p.Role,
                p => p.MapFrom(q => q.Role))
                .ForMember(p => p.UserAddresses,
                    p => p.MapFrom(q => q.UserAddresses));

            config.CreateMap<User, UserDto>()
                .ForMember(p => p.Role,
                    p => p.MapFrom(q => q.Role))
                .ForMember(p => p.UserAddresses,
                    p => p.MapFrom(q => q.UserAddresses));

            config.CreateMap<User, CreateUserDto>().ReverseMap();

            config.CreateMap<UserAddress, UserAddressDto>()
                .ForMember(p => p.User,
                    p => p.MapFrom(q => q.User));
            config.CreateMap<CreateUserAddressDto, UserAddress>().ReverseMap();
            config.CreateMap<UpdateUserAddressDto, UserAddress>().ReverseMap();

            #endregion

            #region Product Config

            config.CreateMap<CreateProductDto, Product>().ReverseMap();

            #endregion

            #region Inventory Config

            config.CreateMap<Inventory, CreateInventoryDto>().ReverseMap();

            #endregion
        });
        return mappingConfig;
    }
}