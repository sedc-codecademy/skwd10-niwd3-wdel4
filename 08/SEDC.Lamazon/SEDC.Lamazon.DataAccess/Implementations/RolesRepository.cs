using SEDC.Lamazon.DataAccess.DataContext;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        public RolesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public List<Role> GetAll()
        {
            return _applicationDbContext.Roles.ToList();
        }

        public Role GetRoleByKey(string key)
        {
            return _applicationDbContext.Roles.FirstOrDefault(x => x.Key == key);
        }
    }
}
