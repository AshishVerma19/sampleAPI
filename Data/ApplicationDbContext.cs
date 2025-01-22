using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sampleAPI.Models;

namespace sampleAPI.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
