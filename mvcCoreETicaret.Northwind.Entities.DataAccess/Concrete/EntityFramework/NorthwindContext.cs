using Microsoft.EntityFrameworkCore;
using mvcCoreETicaret.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvcCoreETicaret.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
       
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7GB2ORJ;Initial Catalog=NORTHWND;Integrated Security=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
