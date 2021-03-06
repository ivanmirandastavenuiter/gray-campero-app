// <auto-generated />
using GC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GC.Migrations
{
    [DbContext(typeof(GCContext))]
    [Migration("20211020011531_GCDefaultMigration")]
    partial class GCDefaultMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GC.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId", "ProductId", "UserId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartId = 3000,
                            ProductId = 2000,
                            UserId = 1001,
                            Quantity = 1,
                            Status = "ACTIVE"
                        },
                        new
                        {
                            CartId = 3000,
                            ProductId = 2001,
                            UserId = 1001,
                            Quantity = 3,
                            Status = "ACTIVE"
                        },
                        new
                        {
                            CartId = 3000,
                            ProductId = 2003,
                            UserId = 1001,
                            Quantity = 2,
                            Status = "ACTIVE"
                        },
                        new
                        {
                            CartId = 3001,
                            ProductId = 2009,
                            UserId = 1002,
                            Quantity = 1,
                            Status = "ACTIVE"
                        },
                        new
                        {
                            CartId = 3001,
                            ProductId = 2010,
                            UserId = 1002,
                            Quantity = 2,
                            Status = "ACTIVE"
                        });
                });

            modelBuilder.Entity("GC.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UrlPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 2000,
                            Description = "Amazing yummy bacon",
                            Name = "Bacon",
                            Price = 0.75f,
                            Stock = 5,
                            UrlPath = "bacon.jpg"
                        },
                        new
                        {
                            ProductId = 2001,
                            Description = "Amazing yummy onion",
                            Name = "Onion",
                            Price = 0.25f,
                            Stock = 13,
                            UrlPath = "onion.jpg"
                        },
                        new
                        {
                            ProductId = 2002,
                            Description = "Amazing yummy lettuce",
                            Name = "Lettuce",
                            Price = 0.2f,
                            Stock = 25,
                            UrlPath = "lettuce.jpg"
                        },
                        new
                        {
                            ProductId = 2003,
                            Description = "Amazing yummy cheese",
                            Name = "Cheese",
                            Price = 0.99f,
                            Stock = 4,
                            UrlPath = "cheese.jpg"
                        },
                        new
                        {
                            ProductId = 2004,
                            Description = "Amazing yummy tomato",
                            Name = "Tomato",
                            Price = 0.3f,
                            Stock = 5,
                            UrlPath = "tomato.jpg"
                        },
                        new
                        {
                            ProductId = 2005,
                            Description = "Amazing yummy ham",
                            Name = "Ham",
                            Price = 0.45f,
                            Stock = 4,
                            UrlPath = "ham.jpg"
                        },
                        new
                        {
                            ProductId = 2006,
                            Description = "Amazing yummy bread",
                            Name = "Bread",
                            Price = 0.1f,
                            Stock = 70,
                            UrlPath = "bread.jpg"
                        },
                        new
                        {
                            ProductId = 2007,
                            Description = "Amazing yummy mayonnaise",
                            Name = "Mayonnaise",
                            Price = 0.05f,
                            Stock = 4,
                            UrlPath = "mayonnaise.jpg"
                        },
                        new
                        {
                            ProductId = 2008,
                            Description = "Amazing yummy yogurt sauce",
                            Name = "Yogurt sauce",
                            Price = 0.15f,
                            Stock = 123,
                            UrlPath = "yogurt-sauce.jpg"
                        },
                        new
                        {
                            ProductId = 2009,
                            Description = "Amazing yummy chicken",
                            Name = "Chicken",
                            Price = 1.25f,
                            Stock = 3,
                            UrlPath = "chicken.jpg"
                        },
                        new
                        {
                            ProductId = 2010,
                            Description = "Amazing yummy arugula",
                            Name = "Arugula",
                            Price = 0.08f,
                            Stock = 3,
                            UrlPath = "arugula.jpg"
                        },
                        new
                        {
                            ProductId = 2011,
                            Description = "Amazing yummy carrot",
                            Name = "Carrot",
                            Price = 0.02f,
                            Stock = 5,
                            UrlPath = "carrot.jpg"
                        },
                        new
                        {
                            ProductId = 2012,
                            Description = "Amazing yummy lamb",
                            Name = "Lamb",
                            Price = 2f,
                            Stock = 10,
                            UrlPath = "lamb.jpg"
                        },
                        new
                        {
                            ProductId = 2013,
                            Description = "Amazing yummy pork",
                            Name = "Pork",
                            Price = 0.65f,
                            Stock = 12,
                            UrlPath = "pork.jpg"
                        });
                });

            modelBuilder.Entity("GC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1001,
                            Email = "ivanmist90@gmail.com",
                            Lastname = "Miranda Stavenuiter",
                            Name = "Iván"
                        },
                        new
                        {
                            UserId = 1002,
                            Email = "gc-admin@gmail.com",
                            Lastname = "gc-admin",
                            Name = "GCAdmin"
                        });
                });

            modelBuilder.Entity("GC.Models.Cart", b =>
                {
                    b.HasOne("GC.Models.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GC.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GC.Models.Product", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("GC.Models.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
