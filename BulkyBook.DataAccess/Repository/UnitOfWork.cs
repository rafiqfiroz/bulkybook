using Bulkybook.Models.Models;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CategoryDbContext _db;
        public UnitOfWork(CategoryDbContext db)
        {
            _db = db;
            Category =new CategoryRepository(_db);
        }

        public ICategoryRepository Category { get; private set;}

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
