using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.DataAccess;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Core.EntityFremawork
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        DbContext _db;
        DbSet<T> _dbSet;
        public RepositoryBase(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public int Add(T entity)
        {
            
            _dbSet.Add(entity);
            entity.IsActive = true;
            return _db.SaveChanges();
        }

        public int Delete(T entity)
        {
            entity.IsActive = false;
            _dbSet.Update(entity);
            return _db.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _dbSet.Where(x => x.IsActive == true).ToList() : _dbSet.Where(expression).Where(x => x.IsActive== true).ToList();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking<T>().FirstOrDefault(expression);
        }
        public int Update(T entity)
        {
            _dbSet.Update(entity);
            return _db.SaveChanges();
        }
    }
}
