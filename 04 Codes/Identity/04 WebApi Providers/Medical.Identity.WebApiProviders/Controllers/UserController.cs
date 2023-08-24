using Medical.Identity.EntityProviders;
using Medical.Identity.LogicProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;
using System.Threading.Tasks;
using System;

namespace Medical.Identity.WebApiProviders;

[Authorize]
public class UserController : BaseIdentityWebApiController<User, IUserLogicProviders, IdentityDbContext>
{
    #region [ CTor ]
    public UserController(ILogger<BaseWebApiController<User, IUserLogicProviders, IdentityDbContext>> logger, IUserLogicProviders logicProvider, IdentityLogicContext logicContext) : base(logger, logicProvider, logicContext)
    {
    }
    #endregion

    #region [ Methods -  ]
    [AllowAnonymous]
    [HttpPost(nameof(IdentityMethodUrl.SignIn))]
    public async Task<IActionResult> SignInAsync([FromBody] SignInModel model)
    {
        try
        {
            var apiResponse = new SignInResponseModel();
            var result = await this._logicProvider.GetSingleBySignInAsync(model);

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
}
