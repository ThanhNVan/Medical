using Medical.Identity.EntityProviders;
using Medical.Identity.LogicProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Medical.Identity.WebApiProviders;

[Authorize]
[ApiController]
[Route("Api/V1/[controller]")]
public class AuthenticationController : ControllerBase
{
    #region [ Fields ]
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IdentityLogicContext _context;
    #endregion

    #region [ CTor ]
    public AuthenticationController(ILogger<AuthenticationController> logger,
                                    IdentityLogicContext context)
    {
        this._logger = logger;
        this._context = context;
    }
    #endregion

    #region [ Methods - Sign In ]
    [AllowAnonymous]
    [HttpPost(nameof(IdentityMethodUrl.SignIn))]
    public async Task<IActionResult> SignInAsync([FromBody] SignInModel model)
    {
        try
        {
            var apiResponse = new SignInResponseModel();
            var result = await this._context.User.GetSingleBySignInAsync(model);

            if (result == null)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Not correct Email or Password";
                apiResponse.Model = null;
                return BadRequest(apiResponse);
            }

            apiResponse.Success = true;
            apiResponse.Message = "Ok";
            apiResponse.Model = result;
            return Ok(apiResponse);

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region [ Methods - RenewToken ]
    [HttpPost(nameof(IdentityMethodUrl.RenewToken))]
    public async Task<IActionResult> RenewTokenAsync([FromBody] TokenModel TokenModel)
    {
        try
        {
            var result = await this._context.User.RenewTokenAsync(TokenModel);
            if (result == null)
            {
                return BadRequest("Something Is wrong, please try again");
            }
            return Ok(result);

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion
}
