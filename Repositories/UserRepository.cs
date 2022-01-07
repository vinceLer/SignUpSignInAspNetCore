using SignUpSignInAspNetCore.Interfaces;
using SignUpSignInAspNetCore.Models;
using SignUpSignInAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SignUpSignInAspNetCore.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public List<User> GetAll()
        {
            return _dataContext.Users.ToList();
        }

        public User GetT(int id)
        {
            return _dataContext.Users.Find(id);
        }

        public bool Save(User entity)
        {
            _dataContext.Users.Add(entity);
            return _dataContext.SaveChanges() > 0;
        }

        public List<User> Search(Expression<Func<User, bool>> searchMethod)
        {
            return _dataContext.Users.Where(searchMethod).ToList();
        }

        public User SearchOne(Expression<Func<User, bool>> searchMethod)
        {
            return _dataContext.Users.SingleOrDefault(searchMethod);
        }

        public bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}
