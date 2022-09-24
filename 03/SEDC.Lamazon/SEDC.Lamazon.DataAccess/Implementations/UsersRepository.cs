using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class UsersRepository : IRepository<User>
    {
        public void DeleteById(int id)
        {
            var user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception($"User with id {id} was not found.");
            }

            int index = StaticDb.Users.IndexOf(user);
            StaticDb.Users.RemoveAt(index);
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            entity.Id = StaticDb.UserId;
            StaticDb.Users.Add(entity);
            StaticDb.UserId++;
            return entity.Id;
        }

        public void Update(User entity)
        {
            var user = StaticDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user == null)
            {
                throw new Exception($"User with id {user.Id} was not found.");
            }

            int index = StaticDb.Users.IndexOf(user);
            StaticDb.Users[index] = entity;
        }
    }
}
