using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
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

    //[HttpGet(nameof(BaseMethodUrl.Add))]
    //public virtual async Task<IActionResult> AddAsync()
    //{
    //    try
    //    {

    //        return Ok();

    //    } catch (ArgumentNullException ex)
    //    {
    //        this._logger.LogError(ex.Message);
    //        return BadRequest();
    //    } catch (Exception ex)
    //    {
    //        this._logger.LogError(ex.Message);
    //        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
    //    }
    //}
}
