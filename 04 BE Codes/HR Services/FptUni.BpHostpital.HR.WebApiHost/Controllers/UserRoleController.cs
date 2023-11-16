using FptUni.BpHospital.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class UserRoleController : BaseWebApiController<UserRole, IUserRoleService, HrDbContext>
{
    #region [ CTor ]
    public UserRoleController(ILogger<UserRoleController> logger, IUserRoleService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    #region [ Methods - List ]

    [HttpGet(nameof(UrlConstant.GetListByUserId) + "/{userId}")]
    public async Task<IActionResult> GetListByUserIdAsync(string userId)
    {
        try
        {
            var result = await this._service.GetListByUserIdAsync(userId);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);

        } catch (ArgumentNullException ex)
        {
            this._logger.LogError(ex.Message);
            return BadRequest();
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion
}
