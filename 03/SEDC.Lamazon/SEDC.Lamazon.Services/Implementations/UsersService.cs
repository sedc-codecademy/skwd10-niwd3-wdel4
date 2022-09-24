using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IRepository<User> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
        }

        public void CreateUser(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            var userId = _usersRepository.Insert(user);
            if (userId <= 0)
            {
                throw new Exception($"something went wrong while saving the new user.");
            }
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
            var user = _mapper.Map<User>(userViewModel);
            _usersRepository.Update(user);
        }
    }
}
