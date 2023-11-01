using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = nameof(RoleConstants.HRManager))]
public class OccupationController : BaseWebApiController<Occupation, IOccupationService, HrDbContext>
{
    #region [ CTor ]
    public OccupationController(ILogger<OccupationController> logger, IOccupationService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
