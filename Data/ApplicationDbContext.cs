using BookaBook.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookaBook.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Livre> Livres { get; set; }
    public DbSet<Emprunt> Emprunts { get; set; }
    public DbSet<Favoris> Favoris { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ActionUser ne sera pas mappée car elle est abstraite
        modelBuilder.Ignore<UserAction>();

        // Lecture et désérialisation des données JSON pour les catégories
        string CategoryJSon = System.IO.File.ReadAllText("categories.Json");
        List<Category>? categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(CategoryJSon);
        if (categories != null)
        {
            foreach (Category cat in categories)
            {
                cat.Id = Guid.Parse(cat.Id.ToString());
                modelBuilder.Entity<Category>().HasData(cat);
            }
        }

        // Lecture et désérialisation des données JSON pour les livres
        string LivreJSon = System.IO.File.ReadAllText("livres.Json");
        List<Livre>? livres = System.Text.Json.JsonSerializer.Deserialize<List<Livre>>(LivreJSon);
        if (livres != null)
        {
            foreach (Livre l in livres)
            {
                l.Id = Guid.Parse(l.Id.ToString()!);
                modelBuilder.Entity<Livre>().HasData(l);
            }
        }

        
    }
}
