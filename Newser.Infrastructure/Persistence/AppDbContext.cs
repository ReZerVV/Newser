using Microsoft.EntityFrameworkCore;
using Newser.Domain.Entities;

namespace Newser.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    public AppDbContext(DbContextOptions options)
        : base(options)
    {

    }
}