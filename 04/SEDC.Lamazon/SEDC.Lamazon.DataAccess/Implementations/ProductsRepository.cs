using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductsRepository : IRepository<Product>
    {
        public void DeleteById(int id)
        {
            var product = StaticDb.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} was not found");
            }

            int index = StaticDb.Products.IndexOf(product);
            StaticDb.Products.RemoveAt(index);
        }

        public List<Product> GetAll()
        {
            return StaticDb.Products;
        }

        public Product GetById(int id)
        {
            return StaticDb.Products.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Product product)
        {
            product.Id = StaticDb.ProductId;
            StaticDb.Products.Add(product);
            StaticDb.ProductId++;
            return product.Id;
        }

        public void Update(Product product)
        {
            var entity = StaticDb.Products.FirstOrDefault(x => x.Id == product.Id);
            if (entity == null)
            {
                throw new Exception($"Product with id {product.Id} was not found");
            }

            int index = StaticDb.Products.IndexOf(entity);
            StaticDb.Products[index] = product;
        }
    }
}
