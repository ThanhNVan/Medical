using System.Net.Http;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class UserHttpClientProviders : BaseHrHttpClientProviders<User>, IUserHttpClientProviders
{
    #region [ CTor ]
    public UserHttpClientProviders(IHttpClientFactory httpClientFactory, ILogger<UserHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(httpClientFactory, logger, encriptionProvider)
    {
        this._entityUrl = EntityUrl.User;
    }
    #endregion
}
