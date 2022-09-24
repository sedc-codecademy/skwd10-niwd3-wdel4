using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IRepository<ProductCategory> _productCategoriesRepository;
        private readonly IMapper _mapper;

        public ProductCategoriesService(IRepository<ProductCategory> productCategoriesRepository, IMapper mapper)
        {
            _productCategoriesRepository = productCategoriesRepository;
            _mapper = mapper;
        }

        public void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
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
            return _mapper.Map<List<ProductCategoryViewModel>>(productCategories);
        }

        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            var productCategory = _productCategoriesRepository.GetById(id);
            return _mapper.Map<ProductCategoryViewModel>(productCategory);
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
            _productCategoriesRepository.Update(productCategory);
        }
    }
}
