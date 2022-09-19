using SEDC.Lamazon.Models.Domain;
using System.Collections.Generic;

namespace SEDC.Lamazon
{
    public static class StaticDb
    {
        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Introduction to ASP.NET MVC",
                Description = "basic info and bla bla bla about MVC",
                CategoryType = Models.Enums.CategoryType.Books,
                Price = 147
            },
            new Product
            {
                Id = 2,
                Name = "Coca Cola",
                Description = "The most generic drink",
                CategoryType = Models.Enums.CategoryType.Drinks,
                Price = 2
            },
            new Product
            {
                Id = 3,
                Name = "Surfcae Laptop 3",
                Description = "Bla bla bla",
                CategoryType = Models.Enums.CategoryType.Electronics,
                Price = 3000
            },
            new Product
            {
                Id = 4,
                Name = "chicken wings",
                Description = "The best chicken wing in the world",
                CategoryType = Models.Enums.CategoryType.Food,
                Price = 5
            },
            new Product
            {
                Id = 4,
                Name = "Hamburger 7ca",
                Description = "It is not what it use to be",
                CategoryType = Models.Enums.CategoryType.Food,
                Price = 3
            },
            new Product
            {
                Id = 5,
                Name = "Pragmatic programmer",
                Description = "Onether book",
                CategoryType = Models.Enums.CategoryType.Other,
                Price = 1000
            }
        };
    }
}
