using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class ProductsService : IProductsServices
    {
        private readonly IRepository<Product> _productRepository;
        public ProductsService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void CreateProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ToProduct();
            int productId = _productRepository.Insert(product);
            if (productId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new product");
            }
        }

        public void DeleteProductById(int id)
        {
            _productRepository.DeleteById(id);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products.ToProductViewModelList();
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return product.ToProductViewModel();
        }

        public void UpdateProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ToProduct();
            _productRepository.Update(product);
        }
    }
}
