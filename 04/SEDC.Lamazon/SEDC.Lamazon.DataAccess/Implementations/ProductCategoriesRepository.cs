using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.DataContext;
using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductCategoriesRepository : BaseRepository, IRepository<ProductCategory>
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
