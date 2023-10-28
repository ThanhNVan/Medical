using System.Net.Http;
using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.HttpClientProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public class UserHttpClientProviders : BaseHttpClientProvider<User>, IUserHttpClientProviders
{
    #region [ CTor ]
    public UserHttpClientProviders(IHttpClientFactory httpClientFactory, ILogger<UserHttpClientProviders> logger, IEncriptionProvider encriptionProvider) : base(httpClientFactory, logger, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Override ]
    public async override Task<bool> AddAsync(string emailKey, User entity, string accessToken, string clientName = "HrClient")
    {
        return await base.AddAsync(emailKey, entity, clientName, accessToken);
    }

    public async override Task<User> GetSingleByIdAsync(string emailKey, string id, string accessToken, string clientName = "HrClient")
    {
        return await base.GetSingleByIdAsync(emailKey,id, clientName, accessToken);
    }

    public async override Task<bool> UpdateAsync(string emailKey, User entity, string accessToken, string clientName = "HrClient")
    {
        return await base.UpdateAsync(emailKey, entity, clientName, accessToken);
    }
    #endregion
}
