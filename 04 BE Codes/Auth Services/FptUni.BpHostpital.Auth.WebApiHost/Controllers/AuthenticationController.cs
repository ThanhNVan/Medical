using FptUni.BpHostpital.Auth.Services;
using FptUni.BpHostpital.Auth.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using System;
using System.Threading.Tasks;

namespace FptUni.BpHostpital.Auth.WebApiHost;

[Route("Api/[controller]")]
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

    #region [ Methods - SignOut ]

    #endregion

    #region [ Methods - RenewToken ]

    #endregion
}
