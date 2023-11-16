using System;
using System.Threading.Tasks;
using FptUni.BpHospital.Common;
using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class ProfileController : BaseWebApiController<Profile, IProfileService, HrDbContext>
{
    #region [ CTor ]
    public ProfileController(ILogger<ProfileController> logger, IProfileService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    #region [ Methods - Single ]
    [HttpGet(nameof(UrlConstant.GetSingleByUserId) + "/{userId}")]
    public async Task<IActionResult> GetSingleByUserIdAsync(string userId)
    {
        try
        {
            var result = await this._service.GetSingleByUserIdAsync(userId);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);

        } catch(ArgumentNullException ex)
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
