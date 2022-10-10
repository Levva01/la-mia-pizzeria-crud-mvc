using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pizza> Pizze { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredienti> Ingredients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_pizzeria;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>()
            .HasData(
                new Pizza
                {
                    Id = 1,
                    Nome = "Margherita",
                    Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                    Foto = "img/pizza.jpg",
                    Prezzo = 5.00
                },

                new Pizza
                {
                    Id = 2,
                    Nome = "Margherita",
                    Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                    Foto = "img/pizza.jpg",
                    Prezzo = 5.00
                },

                new Pizza
                {
                    Id = 3,
                    Nome = "Margherita",
                    Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                    Foto = "img/pizza.jpg",
                    Prezzo = 5.00
                },

                new Pizza
                {
                    Id = 4,
                    Nome = "Margherita",
                    Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                    Foto = "img/pizza.jpg",
                    Prezzo = 5.00
                },

                new Pizza
                {
                    Id = 5,
                    Nome = "Margherita",
                    Descrizione = "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo",
                    Foto = "img/pizza.jpg",
                    Prezzo = 5.00
                });
        /*
        modelBuilder.Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Pizze Classiche",
                },

                new Category
                {
                    Id = 2,
                    Name = "Pizze Bianche",
                },

                new Category
                {
                    Id = 3,
                    Name = "Pizze Vegetariane",
                },

                new Category
                {
                    Id = 1,
                    Name = "Pizze Di Mare",
                });*/
    }

}