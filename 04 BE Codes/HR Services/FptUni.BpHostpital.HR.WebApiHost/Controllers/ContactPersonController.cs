using ShareLibrary.WebApiProviders;
using FptUni.BpHostpital.HR.Utils;
using FptUni.BpHostpital.HR.Services;
using Microsoft.Extensions.Logging;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class ContactPersonController : BaseWebApiController<ContactPerson, IContactPersonService, HrDbContext>
{
    #region [ CTor ]
    public ContactPersonController(ILogger<BaseWebApiController<ContactPerson, IContactPersonService, HrDbContext>> logger, IContactPersonService logicProvider) : base(logger, logicProvider)
    {
    }
    #endregion
}
