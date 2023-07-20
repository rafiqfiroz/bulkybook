using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CategoryDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(CategoryDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T Entity)
        {
            dbSet.Add(Entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstorDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> Entity)
        {
            dbSet.RemoveRange(Entity);
        }
    }
}
