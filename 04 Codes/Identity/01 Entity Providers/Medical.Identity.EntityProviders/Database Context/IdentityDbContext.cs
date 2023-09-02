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

    public DbSet<Department> Departments { get; set; }
    #endregion

    #region [ Methods - Protected ]
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedData(builder);
    }
    #endregion

    public static void SeedData(ModelBuilder builder)
    {
        
        var department_1 = new Department();
        department_1.Name = "IT";
        
        var department_2 = new Department();
        department_2.Name = "Sales";
        
        var department_3 = new Department();
        department_3.Name = "HR";

        builder.Entity<Department>().HasData(
                department_1, department_2,
               department_3
           );

        var role_0 = new Role();
        role_0.Name = "Staff";
        
        var role_1 = new Role();
        role_1.Name = "Admin";
        
        var role_2 = new Role();
        role_2.Name = "Manager";
        
        var role_3 = new Role();
        role_3.Name = "Doctor";
        
        var role_4 = new Role();
        role_4.Name = "Nurse";
        
        var role_5 = new Role();
        role_5.Name = "Pharmacist";

        var role_6 = new Role();
        role_6.Name = "Director";

        builder.Entity<Role>().HasData(
                role_0, role_1, role_2, role_3, role_4, role_5,
                role_6
            );
    }
}
