using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IProductCategoriesService
    {
        List<ProductCategoryViewModel> GetAllProductCategories();
        ProductCategoryViewModel GetProductCategoryById(int id);
        void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void DeleteProductCategoryById(int id);
    }
}
