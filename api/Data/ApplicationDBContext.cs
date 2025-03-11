using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Coupon> Coupons {get; set;}
        public DbSet<Shipping> Shippings {get; set;}




        // Fake dữ liệu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var users = new List<User>(){
                new User()
                {
                    Id = Guid.Parse("9e4c1467-1426-4b97-902c-bacb85f56cc0"),
                    Email = "jd.shopfashion@gmail.com",
                    Password = "asdasd123123",
                    Phone = "0123456789",
                    Address = "Ha Noi",
                    Role = "Admin",
                    Username = "jdshop"
                },
                new User()
                {
                    Id = Guid.Parse("556ee2c5-6eab-4e10-bfa0-8f2f99003ff8"),
                    Email = "jd.shopfashion1@gmail.com",
                    Password = "asdasd123123",
                    Phone = "0123456789",
                    Address = "Ha Noi",
                    Role = "User",
                    Username = "jdshop"
                },
                
            };
            modelBuilder.Entity<User>().HasData(users);

            var categorys = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("99c00af1-2be2-4c83-a4a3-35f2ad326bb5"),
                    Name = "T-SHIRTS",
                    Description = "Áo Ngắn Tay",
                    CreatedAt = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.Parse("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931"),
                    Name = "PANTS",
                    Description = "Quần",
                    CreatedAt = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.Parse("a59e7340-2a4a-4384-8b9e-2264c462cdfa"),
                    Name = "JACKETS",
                    Description = "Áo khoác",
                    CreatedAt = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.Parse("719730c6-6e98-4300-a064-7c5673ce2f50"),
                    Name = "HOODIES & SWEATSHIRTS",
                    Description = "Sweater",
                    CreatedAt = DateTime.UtcNow,
                },
                new Category()
                {
                    Id = Guid.Parse("84947687-13e1-40c8-8b6e-28f1ae4c8931"),
                    Name = "SHIRT",
                    Description = "Áo sơ mi",
                    CreatedAt = DateTime.UtcNow,
                },
            };
            modelBuilder.Entity<Category>().HasData(categorys);


            var products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Name = "Áo phông nam ngắn tay",
                    Description = "Chiếc áo được làm từ chất liệu vải tổng hợp giúp người mặc cảm thấy thoải mái",
                    StockQuantity = 1000,
                    ImageUrl = "aophong.png",
                    Price = 999000,
                    CategoryId = Guid.Parse("99c00af1-2be2-4c83-a4a3-35f2ad326bb5")
                },
                new Product()
                {
                    Id = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Name = "Áo polo nam",
                    Description = "Chiếc áo được làm từ chất liệu vải tổng hợp giúp người mặc cảm thấy thoải mái",
                    StockQuantity = 1000,
                    ImageUrl = "aopolo.png",
                    Price = 1999000,
                    CategoryId = Guid.Parse("99c00af1-2be2-4c83-a4a3-35f2ad326bb5")
                },
                new Product()
                {
                    Id = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Name = "Áo hoodie",
                    Description = "Chiếc áo hoodie với form dáng oversize, chất liệu vải dày dặn",
                    StockQuantity = 1000,
                    ImageUrl = "aohoodie.png",
                    Price = 299000,
                    CategoryId = Guid.Parse("719730c6-6e98-4300-a064-7c5673ce2f50")
                },
                new Product()
                {
                    Id = Guid.Parse("ec16787e-f650-4a7e-839e-f034b52f9273"),
                    Name = "Áo khoác gió 2 lớp",
                    Description = "Chiếu áo này mặc vào là đẹp",
                    StockQuantity = 100,
                    ImageUrl = "aokhoacgio.png",
                    Price = 599000,
                    CategoryId = Guid.Parse("a59e7340-2a4a-4384-8b9e-2264c462cdfa")
                },
                new Product()
                {
                    Id = Guid.Parse("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"),
                    Name = "Quần jeans ống rộng",
                    Description = "Quần jeans ống rộng phong cách Unisex",
                    StockQuantity = 500,
                    ImageUrl = "quanjeans.png",
                    Price = 599000,
                    CategoryId = Guid.Parse("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931")
                },
                new Product()
                {
                    Id = Guid.Parse("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"),
                    Name = "Quần nỉ ống rộng",
                    Description = "Quần nỉ ống rộng phong cách Unisex",
                    StockQuantity = 500,
                    ImageUrl = "quanni.png",
                    Price = 599000,
                    CategoryId = Guid.Parse("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931")
                },
                new Product()
                {
                    Id = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                    Name = "Quần short",
                    Description = "Quần short phong cách Unisex",
                    StockQuantity = 500,
                    ImageUrl = "quanshort.png",
                    Price = 99000,
                    CategoryId = Guid.Parse("a12dd0e4-3ea2-42e8-bfbd-e2daba5b6931")
                },
            };
            modelBuilder.Entity<Product>().HasData(products);

            var productvariants = new List<ProductVariant>()
            {
                new ProductVariant()
                {
                    Id = Guid.Parse("c0671087-a8f4-4d64-8a5d-7d40572242f7"),
                    Stock =  100,
                    Color = "Đen",
                    Size = "M",
                    Price = 99000,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17")
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Đen",
                    Size = "L",
                    Price = 99000,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17")
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Xanh",
                    Size = "XXL",
                    Price = 99000,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17")
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Trắng",
                    Size = "L",
                    Price = 99000,
                    ProductId = Guid.Parse("ec16787e-f650-4a7e-839e-f034b52f9273")
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Trắng",
                    Size = "XL",
                    Price = 99000,
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Xanh",
                    Size = "28",
                    Price = 99000,
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Đỏ",
                    Size = "L",
                    Price = 99000,
                },
                new ProductVariant()
                {
                    Id = Guid.NewGuid(),
                    Stock =  100,
                    Color = "Trắng",
                    Size = "L",
                    Price = 99000,
                },
                new ProductVariant()
                {
                    Id = Guid.Parse("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"),
                    Stock =  100,
                    Color = "Trắng",
                    Size = "L",
                    Price = 99000,
                },
                new ProductVariant()
                {
                    Id = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Stock =  100,
                    Color = "Trắng",
                    Size = "L",
                    Price = 99000,
                },
            };
            modelBuilder.Entity<ProductVariant>().HasData(productvariants);

            var inventories = new List<Inventory>()
            {
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("ec16787e-f650-4a7e-839e-f034b52f9273"),
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"),
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"),
                },
                new Inventory()
                {
                    Id = Guid.NewGuid(),
                    Stock = 2000,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
            };
            modelBuilder.Entity<Inventory>().HasData(inventories);

            var reviews = new List<Review>()
            {
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Áo đẹp lắm",
                    Rating = 5,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },
                new Review()
                {
                    Id = Guid.NewGuid(),
                    Comment = "Nice",
                    Rating = 4,
                    ProductId = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                },

            };
            modelBuilder.Entity<Review>().HasData(reviews);
        }

    }
}   