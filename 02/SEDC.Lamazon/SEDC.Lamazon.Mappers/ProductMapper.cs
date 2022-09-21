using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                ProductCategory = product.ProductCategory.ToProductCategoryViewModel()
            };
        }

        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                ImageUrl = productViewModel.ImageUrl,
                Price = productViewModel.Price,
                ProductCategory = productViewModel.ProductCategory.ToProductCategory()
            };
        }


        public static List<ProductViewModel> ToProductViewModelList(this List<Product> products)
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                viewModels.Add(product.ToProductViewModel());
            }

            return viewModels;
        }

        public static List<Product> ToProductList(this List<ProductViewModel> productViewModels)
        {
            List<Product> models = new List<Product>();
            foreach (var productViewModel in productViewModels)
            {
                models.Add(productViewModel.ToProduct());
            }

            return models;
        }
    }
}
