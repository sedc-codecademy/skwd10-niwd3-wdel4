using System.Collections.Generic;

namespace SEDC.Lamazon.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
