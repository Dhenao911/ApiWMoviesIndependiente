using Api.W.Movies.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.W.Movies.Backend.DAL;

public class AplicactionDbContext : DbContext
{
    public AplicactionDbContext(DbContextOptions<AplicactionDbContext> options) : base(options)
    {
    }

    private DbSet<Category> Categories { get; set; }
} 