using FptUni.BpHospital.Common.DTOs;
using FptUni.BpHostpital.Auth.Services;
using FptUni.BpHostpital.Auth.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using System;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.Admin))]
[Route("Api/V1/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    #region [ Properties ]
    private readonly JwtSettingModels _jwtSettingModels;
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IUserService _userService;
    #endregion

    #region [ CTor ]
    public AuthenticationController(JwtSettingModels jwtSettingModels,
                                    ILogger<AuthenticationController> logger,
                                    IUserService userService)
    {
        this._jwtSettingModels = jwtSettingModels;
        this._logger = logger;
        this._userService = userService;
    }
    #endregion

    #region [ Methods - SignIn ]
    [AllowAnonymous]
    [HttpPost(nameof(BaseMethodUrl.SignIn))]
    public async Task<IActionResult> SignInAsync([FromBody] SignInModel model)
    {
        try
        {
            var result = await this._userService.SignInAsync(model);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);

        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
    #endregion

    #region [ Methods - SignUp ]
    [HttpPost(nameof(BaseMethodUrl.SignUp))]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpModel model)
    {
        try
        {
            var result = await this._userService.SignUpAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
    #endregion

    #region [ Methods - RenewToken ]
    [HttpPost(nameof(BaseMethodUrl.RenewToken))]
    public async Task<IActionResult> RenewTokenAsync([FromBody] RenewTokenModel model)
    {
        try
        {
            var result = await this._userService.RenewTokenAsync(model);
            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        } catch (Exception ex)
        {
            this._logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }
    #endregion
}
