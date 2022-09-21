using Microsoft.Extensions.DependencyInjection;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Implementations;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Implementations;
using SEDC.Lamazon.Services.Interfaces;
using System;

namespace SEDC.Lamazon.Utilities
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Invoice>, InvoicesRepository>();
            services.AddScoped<IRepository<Order>, OrdersRepository>();
            services.AddScoped<IRepository<ProductCategory>, ProductCategoriesRepository>();
            services.AddScoped<IRepository<Product>, ProductsRepository>();
            services.AddScoped<IRepository<Role>, RolesRepository>();
            services.AddScoped<IRepository<User>, UsersRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IInvoicesService, InvoicesService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IProductCategoriesService, ProductCategoriesService>();
            services.AddScoped<IProductsServices, ProductsService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}
