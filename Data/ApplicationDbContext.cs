using System;
using Microsoft.AspNetCore.Identity;
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
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>{
            new IdentityRole{
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp= "6ac343b0-00ef-4a1c-8f64-68daaca77b5b",
                Id= "6ac343b0-00ef-4a1c-8f64-68daaca77b5b",

            },
            new IdentityRole{
                Name= "User",
                NormalizedName = "USER",
                ConcurrencyStamp= "08beacc0-38dd-42a9-82c1-c3706a0cf19e",
                Id= "08beacc0-38dd-42a9-82c1-c3706a0cf19e"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
