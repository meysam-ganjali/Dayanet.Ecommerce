using AutoMapper;
using Dayanet.Ecommerce.Application.FASADE.Banner;
using Dayanet.Ecommerce.Application.FASADE.Category;
using Dayanet.Ecommerce.Application.FASADE.CategoryAttribute;
using Dayanet.Ecommerce.Application.FASADE.Product;
using Dayanet.Ecommerce.Application.FASADE.Slider;
using Dayanet.Ecommerce.Application.FASADE.Users;
using Dayanet.Ecommerce.Application.Services.Repository.Possition;
using Dayanet.Ecommerce.Application.Services.Repository.Product;
using Dayanet.Ecommerce.Application.Services.Repository.Role;
using Dayanet.Ecommerce.Application.Services.Repository.User;
using Dayanet.Ecommerce.ModelMapper.MappConfig;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Dayanet.Ecommerce.Endpoint.Config;

public static class RegisterServices {
    public static IServiceCollection RegisteratinServices(this IServiceCollection services) {
        services.AddControllersWithViews();
        services.AddAuthorization(options => {
            options.AddPolicy(SD.Admin, policy => policy.RequireRole(SD.Admin));
            options.AddPolicy(SD.Customer, policy => policy.RequireRole(SD.Customer));
        });

        services.AddAuthentication(options => {
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options => {
            options.LoginPath = new PathString("/Auth/Login");
            options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
        });
        services.AddScoped<ICategoryFasade, CategoryFasade>();
        services.AddScoped<ICategoryAttributeFasade, CategoryAttributeFasade>();
        services.AddScoped<ISliderFasade, SliderFasade>();
        services.AddScoped<IPossitionRepository, PossitionRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IBannerFasade, BannerFasade>();
        services.AddScoped<IUserFasade, UserFasade>();
        services.AddScoped<IProductFasade, ProductFasade>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IActivityUserRepository, ActivityUserRepository>();
        IMapper mapper = MappingProfile.RegisterMaps().CreateMapper();
        services.AddSingleton(mapper);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}