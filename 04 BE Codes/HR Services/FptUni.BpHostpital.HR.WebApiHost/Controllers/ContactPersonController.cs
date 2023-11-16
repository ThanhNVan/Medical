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
public class ContactPersonController : BaseWebApiController<ContactPerson, IContactPersonService, HrDbContext>
{
    #region [ CTor ]
    public ContactPersonController(ILogger<ContactPersonController> logger, IContactPersonService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    #region [ Methods - List ]

    [HttpGet(nameof(UrlConstant.GetListByUserId) + "/{userId}")]
    public virtual async Task<IActionResult> GetListByUserIdAsync(string userId)
    {
        try
        {
            var result = await this._service.GetListByUserIdAsync(userId);
            if (result is null || result.Count == 0)
            {
                return NotFound();
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
