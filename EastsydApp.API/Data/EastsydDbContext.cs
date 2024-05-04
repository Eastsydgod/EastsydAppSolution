
//Done By Emmanuel James
using EastsydApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EastsydApp.API.Data
{
    public class EastsydDbContext : DbContext
    {

        public EastsydDbContext(DbContextOptions<EastsydDbContext> options) : base(options)
        {

        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                 .HasKey(u => u.Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(Pc => Pc.Products)
                .WithOne(Pc => Pc.ProductCategory)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<CartItem>()
                .HasKey(c => c.Id);





            //Products
            //Beauty Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Glossier - Beauty Kit",
                Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/Images/Skin-Care/Beauty Kit.jpg",
                Price = 100,
                Qty = 100,
                ProductCategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "elf - Make Up Kit",
                Description = "A kit provided by Curology, containing skin care products",
                ImageURL = "/Images/Skin-Care/elfBeauty.jpg",
                Price = 50,
                Qty = 45,
                ProductCategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Mac  Foundation Powder",
                Description = "Brown Powder by MAC",
                ImageURL = "/Images/Skin-Care/Mc Beauty.jpg",
                Price = 30,
                Qty = 85,
                ProductCategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Rare Beauty Lip Gloss",
                Description = "A kit provided by Curology, it makes ypur lip pop and stand out",
                ImageURL = "/Images/Skin-Care/Lip Gloss two.jpg",
                Price = 20,
                Qty = 30,
                ProductCategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Lip Glow",
                Description = "A kit provided by Schwarzkopf, it makes ypur lip pop and stand out",
                ImageURL = "/Images/Skin-Care/Lip Stick.jpg",
                Price = 50,
                Qty = 60,
                ProductCategoryId = 1

            });
            //Electronics Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Apple Air Pod",
                Description = "Air Pods - in-ear wireless headphones",
                ImageURL = "/Images/Electronics/Airpod 3.jpg",
                Price = 100,
                Qty = 120,
                ProductCategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Airpod & Pack",
                Description = "Airpods  3 ",
                ImageURL = "/Images/Electronics/Airpod and pack.jpg",
                Price = 40,
                Qty = 200,
                ProductCategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Beats Headphones",
                Description = "On-ear Black Headphones - Beats by Dr Dre",
                ImageURL = "/Images/Electronics/Beats Headphone.jpg",
                Price = 40,
                Qty = 300,
                ProductCategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Tozo buds",
                Description = "Black Tozo Headbuds",
                ImageURL = "/Images/Electronics/Tozo Earbud.jpg",
                Price = 600,
                Qty = 20,
                ProductCategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Tripod",
                Description = "Tripod",
                ImageURL = "/Images/Electronics/Tripod.jpg",
                Price = 500,
                Qty = 15,
                ProductCategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Iphone 11",
                Description = "Black Iphone 11 Pro",
                ImageURL = "/Images/Electronics/Iphone.jpg",
                Price = 100,
                Qty = 60,
                ProductCategoryId = 3
            });
            //Furniture Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Black Big Chair",
                Description = "Very comfortable black chair",
                ImageURL = "/Images/Furniture/bigChair.jpg",
                Price = 50,
                Qty = 212,
                ProductCategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Gaming Chair",
                Description = "Very comfortable pink and black leather gaming chair",
                ImageURL = "/Images/Furniture/chair 2.jpg",
                Price = 50,
                Qty = 112,
                ProductCategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,

                Name = "Lounge Chair",
                Description = "Very comfortable lounge chair",
                ImageURL = "/Images/Furniture/chair one.jpg",
                Price = 70,
                Qty = 90,
                ProductCategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                Name = "Solid Lamp",
                Description = "Office Table Lamp",
                ImageURL = "/Images/Furniture/Lamp.jpg",
                Price = 20,
                Qty = 73,
                ProductCategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                Name = "Desk",
                Description = "Very comfortable office desk",
                ImageURL = "/Images/Furniture/Desk.jpg",
                Price = 70,
                Qty = 90,
                ProductCategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                Name = "Full set Sofa",
                Description = "Ash family chairs, full set.",
                ImageURL = "/Images/Furniture/family chair.jpg",
                Price = 15,
                Qty = 100,
                ProductCategoryId = 2
            });
            //Shoes Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                Name = "Addidas Sneakers",
                Description = "Comfortable addidas Sneakers in most sizes",
                ImageURL = "/Images/Shoes/Addidas.jpg",
                Price = 100,
                Qty = 50,
                ProductCategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                Name = "Chelsea Boot",
                Description = "Brown Chelsea Boots  - available in most sizes",
                ImageURL = "/Images/Shoes/Chelsea Boot.jpg",
                Price = 150,
                Qty = 60,
                ProductCategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 20,
                Name = " Nike Air Max",
                Description = " Nike Air Max - available in most sizes",
                ImageURL = "/Images/Shoes/Nike Air Max.jpg",
                Price = 200,
                Qty = 70,
                ProductCategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 21,
                Name = "Nike Dunk Low",
                Description = "Nike Dunk Low - available in most sizes",
                ImageURL = "/Images/Shoes/Nike Dunk Low.jpg",
                Price = 120,
                Qty = 120,
                ProductCategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 22,
                Name = "Addidas  Busekitz",
                Description = "Addidas  Busekitz - available in most sizes",
                ImageURL = "/Images/Shoes/Puma.jpg",
                Price = 200,
                Qty = 100,
                ProductCategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 23,
                Name = "Sketchers Trainers",
                Description = "Sketchers Trainers - available in most sizes",
                ImageURL = "/Images/Shoes/Sketchers.jpg",
                Price = 50,
                Qty = 150,
                ProductCategoryId = 4
            });

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Bob"

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "Sarah"

            });

            //Create Shopping Cart for Users
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = 2

            });
            //Add Product Categories
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                Name = "Beauty",
                IconCss = "fa-solid fa-pump-soap"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                Name = "Furniture",
                IconCss = "fa-solid fa-couch"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                Name = "Electronics",
                IconCss = "fa-solid fa-plug"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 4,
                Name = "Shoes",
                IconCss = "fa-solid fa-shoe-prints"
            });

        }
    }
}
