using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.DataContext;
using SEDC.Lamazon.DataAccess.Implementations;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Implementations;
using SEDC.Lamazon.Services.Interfaces;
using System;

namespace SEDC.Lamazon.Services.Extensions
{
    public static class InjectionExtensions
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Invoice>, InvoicesRepository>();
            services.AddScoped<IRepository<Order>, OrdersRepository>();
            services.AddScoped<IRepository<ProductCategory>, ProductCategoriesRepository>();
            services.AddScoped<IRepository<Product>, ProductsRepository>();
            services.AddScoped<IRepository<Role>, RolesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IInvoicesService, InvoicesService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IProductCategoriesService, ProductCategoriesService>();
            services.AddScoped<IProductsServices, ProductsService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddSingleton<ILocalizationService, LocalizationService>();
        }

        public static void InjectAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
