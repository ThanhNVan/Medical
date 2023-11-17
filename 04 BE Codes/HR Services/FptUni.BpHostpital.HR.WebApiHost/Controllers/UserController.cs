using System;
using System.Threading.Tasks;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class UserController : BaseWebApiController<User, IUserService, HrDbContext>
{
    #region [ CTor ]
    public UserController(ILogger<UserController> logger, IUserService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    #region [ Methods - List ]

    [HttpGet(nameof(UrlConstant.GetListByOccupationId) + "/{occupationId}")]
    public async Task<IActionResult> GetListByOccupationIdAsync(string occupationId)
    {
        try
        {
            var result = await this._service.GetListByOccupationIdAsync(occupationId);
            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);

        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
    
    [HttpGet(nameof(UrlConstant.GetListByDepartmentId) + "/{departmentId}")]
    public async Task<IActionResult> GetListByDepartmentIdAsync(string departmentId)
    {
        try
        {
            var result = await this._service.GetListByDepartmentIdAsync(departmentId);
            if (result is null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);

        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
    #endregion


    #region [ Methods - Single ]
    [HttpGet(nameof(UrlConstant.GetUserIdByEmail) + "/{email}")]
    public async Task<IActionResult> GetUserIdByEmailAsync(string email)
    {
        try
        {
            var result = await this._service.GetUserIdByEmailAsync(email);
            if (string.IsNullOrEmpty(email))
            {
                return NotFound();
            }

            return Ok(new KeyIntValueStringModel { Key =  1, Value = result }) ;

        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
    #endregion
}
