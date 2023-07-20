using Bulkybook.Models.Models;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private CategoryDbContext _db;
        public CategoryRepository(CategoryDbContext db):base(db)
        {
            _db= db;
        }
        
      

        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
