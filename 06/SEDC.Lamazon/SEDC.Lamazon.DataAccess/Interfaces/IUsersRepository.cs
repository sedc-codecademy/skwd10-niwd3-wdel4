using SEDC.Lamazon.Domain.Enitities;
using System.Collections.Generic;

namespace SEDC.Lamazon.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        int Insert(User entity);
        void Update(User entity);
        void DeleteById(int id);
    }
}
