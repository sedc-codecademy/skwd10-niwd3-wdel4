using AutoMapper;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Constants;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Helpers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UserViewModel RegisterUser(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            PasswordHashedHelper.HashPassword(user, userViewModel.Password);
            user.RoleKey = Roles.User;
            var userId = _usersRepository.Insert(user);
            if(userId <= 0)
            {
                throw new Exception("User not saved.");
            }
            return GetUserById(user.Id);
        }

        public void DeleteUserById(int id)
        {
            _usersRepository.DeleteById(id);
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users = _usersRepository.GetAll();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _usersRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            var user = _usersRepository.GetById(userViewModel.Id);
            user.RoleKey = userViewModel.RoleKey;
            _usersRepository.Update(user);
        }

        public UserViewModel ValidateUser(UserCredentialsViewModel userCredentialsViewModel)
        {
            var user = _usersRepository.GetByEmail(userCredentialsViewModel.Email);
            if(user == null)
            {
                return null;
            }
            else
            {
                var passwordVerificationResult = PasswordHashedHelper.VerifyHashedPassword(user, userCredentialsViewModel.Password);

                if(passwordVerificationResult == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
                {
                    return new UserViewModel();
                }
                else
                {
                    return _mapper.Map<UserViewModel>(user);
                }
            }
        }

        public PagedResultViewModel<UserViewModel> GetFilteredUsers(UsersDatatableRequestViewModel usersDatatableRequestViewModel)
        {
            var searchValue = usersDatatableRequestViewModel.search?.value ?? string.Empty;
            var usersPagedResult = _usersRepository.GetFilteredUsers(usersDatatableRequestViewModel.RoleKey,
                                                                     usersDatatableRequestViewModel.start,
                                                                     usersDatatableRequestViewModel.length,
                                                                     searchValue,
                                                                     usersDatatableRequestViewModel.sortColumn,
                                                                     usersDatatableRequestViewModel.isAscending);

            return _mapper.Map<PagedResultViewModel<UserViewModel>>(usersPagedResult);
        }

        public bool HasOtherAdmins(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            return _usersRepository.HasOtherAdmins(user);
        }
    }
}
