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
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    #endregion
}
