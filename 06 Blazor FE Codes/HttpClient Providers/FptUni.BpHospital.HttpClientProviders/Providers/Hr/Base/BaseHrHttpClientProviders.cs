using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.HttpClientProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public abstract class BaseHrHttpClientProviders<TEntity> : BaseHttpClientProvider<TEntity>
    where TEntity : BaseEntity
{
    #region [ CTor ]
    public BaseHrHttpClientProviders(IHttpClientFactory httpClientFactory, ILogger<BaseHttpClientProvider<TEntity>> logger, IEncriptionProvider encriptionProvider) : base(httpClientFactory, logger, encriptionProvider)
    {
    }
    #endregion

    #region [ Methods - Override ]
    public async override Task<bool> AddAsync(string emailKey, TEntity entity, string accessToken, string clientName = "HrClient")
    {
        return await base.AddAsync(emailKey, entity, "HrClient", accessToken);
    }

    public async override Task<TEntity> GetSingleByIdAsync(string emailKey, string id, string accessToken, string clientName = "HrClient")
    {
        return await base.GetSingleByIdAsync(emailKey, id, clientName, accessToken);
    }

    public async override Task<bool> UpdateAsync(string emailKey, TEntity entity, string accessToken, string clientName = "HrClient")
    {
        return await base.UpdateAsync(emailKey, entity, clientName, accessToken);
    }

    public async override Task<bool> SoftDeleteAsync(string emailKey, string entityId, string accessToken, string clientName = "HrClient")
    {
        return await base.SoftDeleteAsync(emailKey, entityId, clientName, accessToken);
    }

    public async override Task<bool> DestroyAsync(string emailKey, string entityId, string accessToken, string clientName = "HrClient")
    {
        return await base.DestroyAsync(emailKey, entityId, clientName, accessToken);
    }

    public async override Task<bool> RecoverAsync(string emailKey, string entityId, string accessToken, string clientName = "HrClient")
    {
        return await base.RecoverAsync(emailKey, entityId, clientName, accessToken);
    }

    public async override Task<IList<TEntity>> GetListAllAsync(string emailKey, string accessToken, string clientName = "HrClient")
    {
        return await base.GetListAllAsync(emailKey, "HrClient", accessToken); 
    }

    public async override Task<IList<TEntity>> GetListIsDeletedAsync(string emailKey, string accessToken, string clientName = "HrClient")
    {
        return await base.GetListIsDeletedAsync(emailKey, clientName, accessToken);
    }

    public async override Task<IList<TEntity>> GetListIsNotDeletedAsync(string emailKey, string accessToken, string clientName = "HrClient")
    {
        return await base.GetListIsNotDeletedAsync(emailKey, clientName, accessToken);
    }

    public async override Task<int> CountAllAsync(string emailKey, string accessToken, string clientName = "HrClient")
    {
        return await base.CountAllAsync(emailKey, clientName, accessToken);
    }

    public async override Task<int> CountIsDeletedAsync(string emailKey, string accessToken, string clientName = "HrClient")
    {
        return await base.CountIsDeletedAsync(emailKey, clientName, accessToken);
    }

    public async override Task<int> CountIsNotDeletedAsync(string emailKey, string accessToken, string clientName = "HrClient")
    {
        return await base.CountIsNotDeletedAsync(emailKey, clientName, accessToken);
    }
    #endregion
}
