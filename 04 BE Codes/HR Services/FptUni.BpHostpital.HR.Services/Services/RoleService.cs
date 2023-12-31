﻿using FptUni.BpHostpital.HR.Repositories;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.Services;

namespace FptUni.BpHostpital.HR.Services;

public class RoleService : BaseServices<Role, IRoleRepository, HrDbContext>, IRoleService
{
    #region [ CTor ]
    public RoleService(ILogger<RoleService> logger, IRoleRepository repository, IEncriptionProvider encriptionProvider) : base(logger, repository, encriptionProvider)
    {
    }
    #endregion
}
