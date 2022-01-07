using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SignUpSignInAspNetCore.Interfaces
{
    public interface IRepository<T>
    {
        T GetT(int id);
        List<T> GetAll();
        bool Save(T entity);
        List<T> Search(Expression<Func<T, bool>> searchMethod);
        T SearchOne(Expression<Func<T, bool>> searchMethod);
        bool Update();
    }
}
