﻿using FptUni.BpHostpital.HR.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.HR.Repositories;

public class UserRoleRepository : BaseRepository<UserRole, HrDbContext>, IUserRoleRepository
{
    #region [ CTor ]
    public UserRoleRepository(ILogger<UserRoleRepository> logger, IDbContextFactory<HrDbContext> dbContextFactory, IEncriptionProvider encriptionProvider) : base(logger, dbContextFactory, encriptionProvider)
    {
    }
    #endregion
}
