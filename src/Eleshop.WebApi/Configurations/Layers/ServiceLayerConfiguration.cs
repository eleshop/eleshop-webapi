using Eleshop.DataAccess.Interfaces.Telephones;
using Eleshop.Services.Interfaces.Accessories;
using Eleshop.Services.Interfaces.Auth;
using Eleshop.Services.Interfaces.Categories;
using Eleshop.Services.Interfaces.Common;
using Eleshop.Services.Interfaces.Laptops;
using Eleshop.Services.Interfaces.Notifications;
using Eleshop.Services.Interfaces.Telephones;
using Eleshop.Services.Interfaces.Users;
using Eleshop.Services.Services.Accessories;
using Eleshop.Services.Services.Auth;
using Eleshop.Services.Services.Categories;
using Eleshop.Services.Services.Common;
using Eleshop.Services.Services.Laptops;
using Eleshop.Services.Services.Notifications;
using Eleshop.Services.Services.Telephones;
using Eleshop.Services.Services.Users;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.Design;

namespace Eleshop.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<IUserAuthService, UserAuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<ILaptopService, LaptopService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ITelephoneService, TelephoneService>();
        builder.Services.AddScoped<IAccessoryService, AccessoryService>();
        builder.Services.AddScoped<IUserService, UserService>();
        //builder.Services.AddScoped<IAdminUserService, AdminUserService>();
        //builder.Services.AddScoped<IHeadService, HeadService>();
        //builder.Services.AddScoped<IAdminService, AdminService>();
        //builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
        //builder.Services.AddScoped<IHeadAuthService, HeadAuthService>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
    }
}
