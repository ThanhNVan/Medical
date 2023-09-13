using Microsoft.EntityFrameworkCore;

namespace FptUni.BpHostpital.HR.Utils;

public class HrDbContext : DbContext
{
    #region [ CTor ]
    public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
    {

    }
    #endregion

    #region [ Properties - DbSet ]
    public DbSet<ContactPerson> ContactPersons { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    #endregion
}
