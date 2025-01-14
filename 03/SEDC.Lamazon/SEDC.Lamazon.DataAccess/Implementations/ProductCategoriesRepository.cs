﻿using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductCategoriesRepository : IRepository<ProductCategory>
    {
        public void DeleteById(int id)
        {
            var productCategory = StaticDb.ProductCategories.FirstOrDefault(x => x.Id == id);
            if (productCategory == null)
            {
                throw new Exception($"ProductCategory with id {id} was not found");
            }

            int index = StaticDb.ProductCategories.IndexOf(productCategory);
            StaticDb.ProductCategories.RemoveAt(index);
        }

        public List<ProductCategory> GetAll()
        {
            return StaticDb.ProductCategories;
        }

        public ProductCategory GetById(int id)
        {
            return StaticDb.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(ProductCategory entity)
        {
            entity.Id = StaticDb.ProductCategoryId;
            StaticDb.ProductCategories.Add(entity);
            StaticDb.ProductCategoryId++;
            return entity.Id;
        }

        public void Update(ProductCategory entity)
        {
            var productCategory = StaticDb.ProductCategories.FirstOrDefault(x => x.Id == entity.Id);
            if (productCategory == null)
            {
                throw new Exception($"ProductCategory with id {entity.Id} was not found");
            }

            int index = StaticDb.ProductCategories.IndexOf(productCategory);
            StaticDb.ProductCategories[index] = entity;
        }
    }
}
