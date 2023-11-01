using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
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
}
