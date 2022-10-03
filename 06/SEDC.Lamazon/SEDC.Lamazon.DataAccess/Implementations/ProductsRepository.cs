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
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public void DeleteById(int id)
        {
            var product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} was not found");
            }

            _applicationDbContext.Products.Remove(product);
            _applicationDbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _applicationDbContext.Products.ToList();
        }

        public PagedResultModel<Product> GetFilteredProducts(int? categoryId, int startIndex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PagedResultModel<Product>();

            var productsQuery = _applicationDbContext.Products.Include(x => x.ProductCategory).AsQueryable();
            result.TotalRecords = productsQuery.Count();

            if(categoryId.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.ProductCategoryId == categoryId);
            }

            productsQuery = productsQuery.Where(x => x.Name.Contains(searchValue));
            result.TotalDisplayRecords = productsQuery.Count();

            productsQuery = isAscending ? productsQuery.OrderByProperty(orderByColumn)
                                        : productsQuery.OrderByPropertyDescending(orderByColumn);
            result.Items = productsQuery.ToList();

            return result;
        }

        public Product GetById(int id)
        {
            return _applicationDbContext.Products.Include(x => x.ProductCategory).FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Product product)
        {
            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();
            return product.Id;
        }

        public void Update(Product product)
        {
            if (_applicationDbContext.Products.Any(x => x.Id == product.Id))
            {
                _applicationDbContext.Update(product);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Product with id {product.Id} was not found");
            }
        }
    }
}
