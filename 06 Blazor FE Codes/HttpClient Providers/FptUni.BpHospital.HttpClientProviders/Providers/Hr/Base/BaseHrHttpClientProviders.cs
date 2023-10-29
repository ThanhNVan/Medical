using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using FptUni.BpHospital.Common.DTOs;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.HttpClientProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public abstract class BaseHrHttpClientProviders<TEntity> : BaseHttpClientProvider<TEntity>
    where TEntity : BaseEntity
{
    #region [ Properties ]
    protected readonly ISessionStorageService _sessionStorage;
    #endregion

    #region [ CTor ]
    public BaseHrHttpClientProviders(ISessionStorageService _sessionStorage, IHttpClientFactory httpClientFactory, ILogger<BaseHttpClientProvider<TEntity>> logger, IEncriptionProvider encriptionProvider) : base(httpClientFactory, logger, encriptionProvider)
    {
        this._sessionStorage = _sessionStorage;
    }
    #endregion

    #region [ Methods -  ]
    public async Task<bool> AddAsync(TEntity entity)
    {
        var userSession = await this.GetUserSessionAsync();

        return await base.AddAsync(userSession.Email, entity, "HrClient", userSession.AccessToken);
    }

    public async  Task<TEntity> GetSingleByIdAsync(string id)
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.GetSingleByIdAsync(userSession.Email, id,  "HrClient", userSession.AccessToken);
    }

    public async  Task<bool> UpdateAsync(TEntity entity)
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.UpdateAsync(userSession.Email, entity,  "HrClient", userSession.AccessToken);
    }

    public async  Task<bool> SoftDeleteAsync(string entityId)
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.SoftDeleteAsync(userSession.Email, entityId,  "HrClient", userSession.AccessToken);
    }

    public async  Task<bool> DestroyAsync(string entityId)
    {

        var userSession = await this.GetUserSessionAsync();
        return await base.DestroyAsync(userSession.Email, entityId,  "HrClient", userSession.AccessToken);
    }

    public async  Task<bool> RecoverAsync(string entityId)
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.RecoverAsync(userSession.Email, entityId,  "HrClient", userSession.AccessToken);
    }

    public async  Task<IList<TEntity>> GetListAllAsync()
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.GetListAllAsync(userSession.Email, "HrClient", userSession.AccessToken); 
    }

    public async  Task<IList<TEntity>> GetListIsDeletedAsync()
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.GetListIsDeletedAsync(userSession.Email,  "HrClient", userSession.AccessToken);
    }

    public async  Task<IList<TEntity>> GetListIsNotDeletedAsync()
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.GetListIsNotDeletedAsync(userSession.Email,  "HrClient", userSession.AccessToken);
    }

    public async  Task<int> CountAllAsync()
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.CountAllAsync(userSession.Email,  "HrClient", userSession.AccessToken);
    }

    public async  Task<int> CountIsDeletedAsync()
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.CountIsDeletedAsync(userSession.Email,  "HrClient", userSession.AccessToken);
    }

    public async  Task<int> CountIsNotDeletedAsync()
    {
        var userSession = await this.GetUserSessionAsync();
        return await base.CountIsNotDeletedAsync(userSession.Email,  "HrClient", userSession.AccessToken);
    }
    #endregion

    #region [ Methods -  ]
    public async Task<UserSession> GetUserSessionAsync()
    {
        return await this._sessionStorage.GetItemAsync<UserSession>("UserSession");
    }
    #endregion
}
