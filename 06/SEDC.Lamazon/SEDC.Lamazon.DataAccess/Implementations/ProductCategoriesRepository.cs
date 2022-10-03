using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.DataContext;
using SEDC.Lamazon.DataAccess.Extensions;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductCategoriesRepository : BaseRepository, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public void DeleteById(int id)
        {
            var productCategory = _applicationDbContext.ProductCategories.FirstOrDefault(x => x.Id == id);
            if (productCategory == null)
            {
                throw new Exception($"ProductCategory with id {id} was not found");
            }

            _applicationDbContext.ProductCategories.Remove(productCategory);
            _applicationDbContext.SaveChanges();
        }

        public List<ProductCategory> GetAll()
        {
            return _applicationDbContext.ProductCategories.ToList();
        }

        public ProductCategory GetById(int id)
        {
            return _applicationDbContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public PagedResultModel<ProductCategory> GetFilteredProductCategories(int startIdex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PagedResultModel<ProductCategory>();

            var productCategoriesQuery = _applicationDbContext.ProductCategories.AsQueryable();
            result.TotalRecords = productCategoriesQuery.Count();

            productCategoriesQuery = productCategoriesQuery.Where(x => x.Name.Contains(searchValue));
            result.TotalDisplayRecords = productCategoriesQuery.Count();

            productCategoriesQuery = isAscending ? productCategoriesQuery.OrderByProperty(orderByColumn)
                                                 : productCategoriesQuery.OrderByPropertyDescending(orderByColumn);

            result.Items = productCategoriesQuery.Skip(startIdex).Take(count).ToList();

            return result;
        }

        public int Insert(ProductCategory entity)
        {
            _applicationDbContext.ProductCategories.Add(entity);
            _applicationDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(ProductCategory entity)
        {
            if (!_applicationDbContext.ProductCategories.Any(x => x.Id == entity.Id))
            {
                throw new Exception($"ProductCategory with id {entity.Id} was not found");
            }

            _applicationDbContext.ProductCategories.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
