using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Identity.EntityProviders;

public class IdentityDbContext : DbContext
{
    #region [ CTor ]
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }
    #endregion
}
