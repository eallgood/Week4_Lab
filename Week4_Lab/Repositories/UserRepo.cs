using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week4_Lab.Data;
using Week4_Lab.Data.Entities;

namespace Week4_Lab.Repositories
{
    public class UserRepo : IUserRepo
    {
        private AppDbContext dbContext;

        public UserRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetUser(int id)
        {
            return dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return dbContext.Users;
        }

        public void SaveUser(User user)
        {
            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            dbContext.Users.Find(user.Id).Update(user);
            dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = dbContext.Users.Find(id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }
    }
}