﻿using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class UserRoleController : BaseWebApiController<UserRole, IUserRoleService, HrDbContext>
{
    #region [ CTor ]
    public UserRoleController(ILogger<UserRoleController> logger, IUserRoleService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
