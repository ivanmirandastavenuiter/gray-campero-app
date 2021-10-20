using GC.Models;
using Microsoft.EntityFrameworkCore;

namespace GC.Data
{
    public class GCContext : DbContext 
    {
        public GCContext(DbContextOptions<GCContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = 1001,
                        Name = "Iván",
                        Lastname = "Miranda Stavenuiter",
                        Email = "ivanmist90@gmail.com"
                    },
                    new User              
                    {
                        UserId = 1002,
                        Name = "GCAdmin",
                        Lastname = "gc-admin",
                        Email = "gc-admin@gmail.com"
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        ProductId = 2000,
                        Name = "Bacon",
                        Description = "Amazing yummy bacon",
                        Price = 0.75f,
                        Stock = 5,
                        UrlPath = "bacon.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2001,
                        Name = "Onion",
                        Description = "Amazing yummy onion",
                        Price = 0.25f,
                        Stock = 13,
                        UrlPath = "onion.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2002,
                        Name = "Lettuce",
                        Description = "Amazing yummy lettuce",
                        Price = 0.20f,
                        Stock = 25,
                        UrlPath = "lettuce.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2003,
                        Name = "Cheese",
                        Description = "Amazing yummy cheese",
                        Price = 0.99f,
                        Stock = 4,
                        UrlPath = "cheese.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2004,
                        Name = "Tomato",
                        Description = "Amazing yummy tomato",
                        Price = 0.30f,
                        Stock = 5,
                        UrlPath = "tomato.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2005,
                        Name = "Ham",
                        Description = "Amazing yummy ham",
                        Price = 0.45f,
                        Stock = 4,
                        UrlPath = "ham.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2006,
                        Name = "Bread",
                        Description = "Amazing yummy bread",
                        Price = 0.10f,
                        Stock = 70,
                        UrlPath = "bread.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2007,
                        Name = "Mayonnaise",
                        Description = "Amazing yummy mayonnaise",
                        Price = 0.05f,
                        Stock = 4,
                        UrlPath = "mayonnaise.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2008,
                        Name = "Yogurt sauce",
                        Description = "Amazing yummy yogurt sauce",
                        Price = 0.15f,
                        Stock = 123,
                        UrlPath = "yogurt-sauce.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2009,
                        Name = "Chicken",
                        Description = "Amazing yummy chicken",
                        Price = 1.25f,
                        Stock = 3,
                        UrlPath = "chicken.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2010,
                        Name = "Arugula",
                        Description = "Amazing yummy arugula",
                        Price = 0.08f,
                        Stock = 3,
                        UrlPath = "arugula.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2011,
                        Name = "Carrot",
                        Description = "Amazing yummy carrot",
                        Price = 0.02f,
                        Stock = 5,
                        UrlPath = "carrot.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2012,
                        Name = "Lamb",
                        Description = "Amazing yummy lamb",
                        Price = 2f,
                        Stock = 10,
                        UrlPath = "lamb.jpg"
                    },
                    new Product 
                    {
                        ProductId = 2013,
                        Name = "Pork",
                        Description = "Amazing yummy pork",
                        Price = 0.65f,
                        Stock = 12,
                        UrlPath = "pork.jpg"
                    }
                );

                modelBuilder.Entity<Cart>()
                    .HasKey(c => new { c.CartId, c.ProductId, c.UserId });

                modelBuilder.Entity<Cart>().HasData(
                    new Cart 
                    {
                        CartId = 3000,
                        UserId = 1001,
                        ProductId = 2000,
                        Quantity = 1,
                        Status =  "ACTIVE"
                    },
                    new Cart 
                    {
                        CartId = 3000,
                        UserId = 1001,
                        ProductId = 2001,
                        Quantity = 3,
                        Status =  "ACTIVE"
                    },
                    new Cart 
                    {
                        CartId = 3000,
                        UserId = 1001,
                        ProductId = 2003,
                        Quantity = 2,
                        Status = "ACTIVE"
                    },
                    new Cart 
                    {
                        CartId = 3001,
                        UserId = 1002,
                        ProductId = 2009,
                        Quantity = 1,
                        Status =  "ACTIVE"
                    },
                    new Cart 
                    {
                        CartId = 3001,
                        UserId = 1002,
                        ProductId = 2010,
                        Quantity = 2,
                        Status = "ACTIVE"
                    }
                );
                    
        }

    }
}