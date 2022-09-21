using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class RolesService : IRolesService
    {
        private readonly IRepository<Role> _rolesRepository;
        public RolesService(IRepository<Role> rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            var roles = _rolesRepository.GetAll();
            return roles.ToRoleViewModelList();
        }

        public RoleViewModel GetRoleById(int id)
        {
            var role = _rolesRepository.GetById(id);
            return role.ToRoleViewModel();
        }
    }
}
