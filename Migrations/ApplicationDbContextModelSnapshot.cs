﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace la_mia_pizzeria_crud_mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IngredientiPizza", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.Property<int>("PizzasId")
                        .HasColumnType("int");

                    b.HasKey("IngredientsId", "PizzasId");

                    b.HasIndex("PizzasId");

                    b.ToTable("IngredientiPizza");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Ingredienti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pizze");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                            Foto = "img/pizza.jpg",
                            Nome = "Margherita",
                            Prezzo = 5.0
                        },
                        new
                        {
                            Id = 2,
                            Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                            Foto = "img/pizza.jpg",
                            Nome = "Margherita",
                            Prezzo = 5.0
                        },
                        new
                        {
                            Id = 3,
                            Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                            Foto = "img/pizza.jpg",
                            Nome = "Margherita",
                            Prezzo = 5.0
                        },
                        new
                        {
                            Id = 4,
                            Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                            Foto = "img/pizza.jpg",
                            Nome = "Margherita",
                            Prezzo = 5.0
                        },
                        new
                        {
                            Id = 5,
                            Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                            Foto = "img/pizza.jpg",
                            Nome = "Margherita",
                            Prezzo = 5.0
                        });
                });

            modelBuilder.Entity("IngredientiPizza", b =>
                {
                    b.HasOne("la_mia_pizzeria_crud_mvc.Models.Ingredienti", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("la_mia_pizzeria_crud_mvc.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Pizza", b =>
                {
                    b.HasOne("la_mia_pizzeria_crud_mvc.Models.Category", "Category")
                        .WithMany("Pizze")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Category", b =>
                {
                    b.Navigation("Pizze");
                });
#pragma warning restore 612, 618
        }
    }
}
