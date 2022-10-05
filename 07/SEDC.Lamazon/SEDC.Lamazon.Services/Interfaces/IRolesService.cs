using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IRolesService
    {
        List<RoleViewModel> GetAllRoles();
        RoleViewModel GetRoleByKey(string key);
    }
}
