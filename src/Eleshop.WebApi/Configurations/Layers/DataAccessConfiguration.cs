using Eleshop.DataAccess.Interfaces.Accessories;
using Eleshop.DataAccess.Interfaces.Categories;
using Eleshop.DataAccess.Interfaces.Laptops;
using Eleshop.DataAccess.Interfaces.Telephones;
using Eleshop.DataAccess.Interfaces.Users;
using Eleshop.DataAccess.Repository.Accessories;
using Eleshop.DataAccess.Repository.Categories;
using Eleshop.DataAccess.Repository.Laptops;
using Eleshop.DataAccess.Repository.Telephones;
using Eleshop.DataAccess.Repository.Users;

namespace Eleshop.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAccessuaryRepository, AccessoryRepository>();
        builder.Services.AddScoped<ICategoryRepasitory, CategoryRepository>();
        builder.Services.AddScoped<ILaptopRepository, LaptopRepository>();
        builder.Services.AddScoped<ITelephoneRepository, TelephoneRepository>();
        //builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
        //builder.Services.AddScoped<IHeadRepository, HeadRepository>();
        //builder.Services.AddScoped<IAdminRepository, AdminRepository>();
    }
}
