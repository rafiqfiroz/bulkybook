using Bulkybook.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Data
{
    public class CategoryDbContext:DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
