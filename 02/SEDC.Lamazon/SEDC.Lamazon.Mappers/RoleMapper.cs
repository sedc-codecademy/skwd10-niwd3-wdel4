using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class RoleMapper
    {
        public static RoleViewModel ToRoleViewModel(this Role role)
        {
            return new RoleViewModel
            {
                Id = role.Id,
                Key = role.Key,
                Name = role.Name
            };
        }

        public static Role ToRole(this RoleViewModel roleViewModel)
        {
            return new Role
            {
                Id = roleViewModel.Id,
                Key = roleViewModel.Key,
                Name = roleViewModel.Name
            };
        }

        public static List<RoleViewModel> ToRoleViewModelList(this List<Role> roles)
        {
            var viewModels = new List<RoleViewModel>();

            foreach(var role in roles)
            {
                viewModels.Add(role.ToRoleViewModel());
            }

            return viewModels;
        }

        public static List<Role> ToRoleList(this List<RoleViewModel> roleViewModels)
        {
            var models = new List<Role>();

            foreach(var roleViewModel in roleViewModels)
            {
                models.Add(roleViewModel.ToRole());
            }

            return models;
        }
    }
}
