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
        
    }
    #endregion
}
