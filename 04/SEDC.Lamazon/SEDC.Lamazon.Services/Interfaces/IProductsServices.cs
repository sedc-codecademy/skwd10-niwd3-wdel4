using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IProductsServices
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        void CreateProduct(ProductViewModel productViewModel);
        void UpdateProduct(ProductViewModel productViewModel);
        void DeleteProductById(int id);
    }
}
