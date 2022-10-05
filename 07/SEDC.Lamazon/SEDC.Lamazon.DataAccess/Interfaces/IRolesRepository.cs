using SEDC.Lamazon.Domain.Enitities;
using System.Collections.Generic;

namespace SEDC.Lamazon.DataAccess.Interfaces
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role GetRoleByKey(string key);
    }
}
