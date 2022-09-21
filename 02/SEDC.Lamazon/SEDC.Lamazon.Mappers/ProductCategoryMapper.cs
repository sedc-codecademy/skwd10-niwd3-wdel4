using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategoryViewModel ToProductCategoryViewModel(this ProductCategory productCategory)
        {
            return new ProductCategoryViewModel
            {
                Id = productCategory.Id,
                Name = productCategory.Name
            };
        }

        public static ProductCategory ToProductCategory(this ProductCategoryViewModel productCategoryViewModel)
        {
            return new ProductCategory
            {
                Id = productCategoryViewModel.Id,
                Name = productCategoryViewModel.Name
            };
        }

        public static List<ProductCategoryViewModel> ToProductCategoryViewModelList(this List<ProductCategory> productCategories)
        {
            List<ProductCategoryViewModel> viewModels = new List<ProductCategoryViewModel>();
            foreach (var productCategory in productCategories)
            {
                viewModels.Add(productCategory.ToProductCategoryViewModel());
            }

            return viewModels;
        }

        public static List<ProductCategory> ToProductCategoryList(this List<ProductCategoryViewModel> productCategoryViewModels)
        {
            List<ProductCategory> models = new List<ProductCategory>();
            foreach (var productCategoryViewModel in productCategoryViewModels)
            {
                models.Add(productCategoryViewModel.ToProductCategory());
            }

            return models;
        }
    }
}
