using Microsoft.EntityFrameworkCore;

namespace Medical.Identity.EntityProviders;

public class IdentityDbContext : DbContext
{
    #region [ CTor ]
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }
    #endregion

    #region [ Properties - DbSet ]
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }
    #endregion
}
