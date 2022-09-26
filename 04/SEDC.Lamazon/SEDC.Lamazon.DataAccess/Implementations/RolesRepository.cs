using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class RolesRepository : IRepository<Role>
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            return StaticDb.Roles;
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
