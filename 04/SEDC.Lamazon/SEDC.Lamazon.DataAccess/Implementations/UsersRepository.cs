using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.DataContext;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public void DeleteById(int id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception($"User with id {id} was not found.");
            }

            _applicationDbContext.Users.Remove(user);
            _applicationDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _applicationDbContext.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            return _applicationDbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == email);
        }

        public User GetById(int id)
        {
            return _applicationDbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _applicationDbContext.Users.Add(entity);
            _applicationDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(User entity)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user == null)
            {
                throw new Exception($"User with id {user.Id} was not found.");
            }

            _applicationDbContext.Users.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
