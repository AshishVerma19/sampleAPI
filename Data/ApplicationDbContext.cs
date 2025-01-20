using System;
using Microsoft.EntityFrameworkCore;
using sampleAPI.Models;

namespace sampleAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
