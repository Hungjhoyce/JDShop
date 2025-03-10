using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categorys {get; set;}
        public DbSet<ProductVariant> ProductVariants {get; set;}
        public DbSet<Review> Reviews {get; set;}
    }
}