using System;
using Microsoft.AspNetCore.Identity;

namespace sampleAPI.Models;

public class AppUser : IdentityUser
{
    public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
}
