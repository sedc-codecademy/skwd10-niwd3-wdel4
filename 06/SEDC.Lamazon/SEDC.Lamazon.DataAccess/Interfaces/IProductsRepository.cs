using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.DataAccess.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        PagedResultModel<Product> GetFilteredProducts(int? categoryId, int startIndex, int count, string searchValue, string orderByColumn, bool isAscending);
        Product GetById(int id);
        int Insert(Product product);
        void Update(Product product);
        void DeleteById(int id);
    }
}
