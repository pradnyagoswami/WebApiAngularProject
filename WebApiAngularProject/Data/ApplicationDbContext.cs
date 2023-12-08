using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiAngularProject.Model;

namespace WebApiAngularProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
