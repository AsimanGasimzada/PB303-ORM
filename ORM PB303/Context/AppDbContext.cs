using Microsoft.EntityFrameworkCore;
using ORM_PB303.Models;
using System.Reflection;

namespace ORM_PB303.Context;

public class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-U2HDDUL;Database=PB303ORM;Trusted_connection=true;encrypt=false");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors{ get; set; } = null!;
}
