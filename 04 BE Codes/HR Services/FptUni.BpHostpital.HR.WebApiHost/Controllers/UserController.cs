using System.Threading.Tasks;
using System;
using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

//[Authorize(Policy = "Test")]
public class UserController : BaseWebApiController<User, IUserService, HrDbContext>
{
    #region [ CTor ]
    public UserController(ILogger<UserController> logger, IUserService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    [HttpGet]
    [Authorize(Policy = "Staff")]
    public async Task<IActionResult> Demo()
    {
        try
        {
            var result = 1;


            return Ok(result);
        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
}
