using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Services;
using ShoppingListApp.Infrastructure.Data.Common;
using System.Runtime.CompilerServices;

namespace ShoppingListApp.Extensions
{
    public static class ShoppingListServiceCollectionExtenstion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });

            return services;
        }
    }
}
