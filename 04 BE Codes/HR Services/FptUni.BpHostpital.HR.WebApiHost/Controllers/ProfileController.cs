using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class ProfileController : BaseWebApiController<Profile, IProfileService, HrDbContext>
{
    #region [ CTor ]
    public ProfileController(ILogger<BaseWebApiController<Profile, IProfileService, HrDbContext>> logger, IProfileService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
