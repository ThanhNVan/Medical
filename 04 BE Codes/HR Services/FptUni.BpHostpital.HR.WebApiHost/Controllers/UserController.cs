using FptUni.BpHostpital.HR.Services;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShareLibrary.WebApiProviders;

namespace FptUni.BpHostpital.HR.WebApiHost;

[Authorize(Policy = "Test")]
public class UserController : BaseWebApiController<User, IUserService, HrDbContext>
{
    #region [ CTor ]
    public UserController(ILogger<UserController> logger, IUserService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
