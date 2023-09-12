using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.Utils;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    #region [ CTor ]
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    #endregion

    #region [ Properties ]
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    #endregion

    #region [ Methods - Protected ]
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
    }
    #endregion

    #region [ Methods - Seed ]
    public static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Administrator" },
                new IdentityRole() { Name = "Department Director", ConcurrencyStamp = "2", NormalizedName = "Department Director" },
                new IdentityRole() { Name = "HR Staff", ConcurrencyStamp = "3", NormalizedName = "Human Resource Staff" },
                new IdentityRole() { Name = "HR Manager", ConcurrencyStamp = "3", NormalizedName = "Human Resource Manager" },
                new IdentityRole() { Name = "Sales Staff", ConcurrencyStamp = "4", NormalizedName = "Sales Staff" },
                new IdentityRole() { Name = "Sales Manager", ConcurrencyStamp = "5", NormalizedName = "Sales Manager" },
                new IdentityRole() { Name = "General Director", ConcurrencyStamp = "6", NormalizedName = "General Director" }
            );
    }
    #endregion
}
