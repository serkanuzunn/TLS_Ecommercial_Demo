using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        
    }
}
