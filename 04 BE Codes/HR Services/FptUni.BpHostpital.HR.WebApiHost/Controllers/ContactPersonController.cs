using ShareLibrary.WebApiProviders;
using FptUni.BpHostpital.HR.Utils;
using FptUni.BpHostpital.HR.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ShareLibrary.EntityProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class ContactPersonController : BaseWebApiController<ContactPerson, IContactPersonService, HrDbContext>
{
    #region [ CTor ]
    public ContactPersonController(ILogger<ContactPersonController> logger, IContactPersonService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion

    [HttpGet(nameof(BaseMethodUrl.Add))]
    public virtual async Task<IActionResult> AddAsync()
    {
        try
        {



            return Ok();

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
}
