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

   // #region [ Methods - Protected ]
    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    //SeedRoles(builder);
    //}
    //#endregion

    public static void SeedRoles(ModelBuilder builder)
    {
        var role_0 = new Role();
        role_0.Name = "Human Resource";
        
        var role_1 = new Role();
        role_1.Name = "IT";
        
        var role_2 = new Role();
        role_2.Name = "Staff";
        
        var role_3 = new Role();
        role_3.Name = "Admin";
        
        var role_4 = new Role();
        role_4.Name = "Manager";
        
        var role_5 = new Role();
        role_5.Name = "Sales";
        
        var role_6 = new Role();
        role_6.Name = "Doctor";
        
        var role_7 = new Role();
        role_7.Name = "Nurse";
        
        var role_8 = new Role();
        role_8.Name = "Pharmacist";

        builder.Entity<Role>().HasData(
                role_0, role_1, role_2, role_3, role_4, role_5, role_6, role_7, role_8
            );
    }
}
