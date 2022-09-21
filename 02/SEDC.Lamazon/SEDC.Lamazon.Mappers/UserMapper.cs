using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role.ToRoleViewModel()
            };
        }

        public static User ToUser(this UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                Email = userViewModel.Email,
                FullName = userViewModel.FullName,
                Role = userViewModel.Role.ToRole()
            };
        }

        public static List<UserViewModel> ToUserViewModelList(this List<User> users)
        {
            var viewModels = new List<UserViewModel>();

            foreach(var user in users)
            {
                viewModels.Add(user.ToUserViewModel());
            }

            return viewModels;
        }

        public static List<User> ToUserList(this List<UserViewModel> userViewModels)
        {
            var models = new List<User>();

            foreach (var userViewModel in userViewModels)
            {
                models.Add(userViewModel.ToUser());
            }

            return models;
        }
    }
}
