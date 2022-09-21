using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IRepository<ProductCategory> _productCategoriesRepository;
        public ProductCategoriesService(IRepository<ProductCategory> productCategoriesRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
        }

        public void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = productCategoryViewModel.ToProductCategory();
            int productCategoryId = _productCategoriesRepository.Insert(productCategory);
            if (productCategoryId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new product category");
            }
        }

        public void DeleteProductCategoryById(int id)
        {
            _productCategoriesRepository.DeleteById(id);
        }

        public List<ProductCategoryViewModel> GetAllProductCategories()
        {
            var productCategories = _productCategoriesRepository.GetAll();
            return productCategories.ToProductCategoryViewModelList();
        }

        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            var productCategory = _productCategoriesRepository.GetById(id);
            return productCategory.ToProductCategoryViewModel();
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = productCategoryViewModel.ToProductCategory();
            _productCategoriesRepository.Update(productCategory);
        }
    }
}
