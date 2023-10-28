using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareLibrary.EntityProviders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShareLibrary.HttpClientProviders;


public abstract class BaseHttpClientProvider<TEntity> : IBaseHttpClientProvider<TEntity>
    where TEntity : BaseEntity
{
    #region [ Fields ]
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly ILogger<BaseHttpClientProvider<TEntity>> _logger;
    protected readonly IEncriptionProvider _encriptionProvider;
    protected string _entityUrl;
    #endregion

    #region [ CTor ]
    public BaseHttpClientProvider(IHttpClientFactory httpClientFactory,
                                    ILogger<BaseHttpClientProvider<TEntity>> logger,
                                    IEncriptionProvider encriptionProvider)
    {

        this._httpClientFactory = httpClientFactory;
        this._logger = logger;
        this._encriptionProvider = encriptionProvider;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    public virtual async Task<bool> AddAsync(string emailKey, TEntity entity, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.Add;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var result = await httpClient.PostAsJsonAsync(url, entity);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<TEntity> GetSingleByIdAsync(string emailKey, string id, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.GetSingleById + id;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<TEntity>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<bool> UpdateAsync(string emailKey, TEntity entity, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.Update;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.PutAsJsonAsync(url, entity);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> SoftDeleteAsync(string emailKey, string entityId, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.SoftDelete + entityId;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<bool> DestroyAsync(string emailKey, string entityId, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.Destroy + entityId;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> RecoverAsync(string emailKey, string entityId, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.Recover;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.PutAsJsonAsync(url, entityId);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<IList<TEntity>> GetListAllAsync(string emailKey, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.GetListAll;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IList<TEntity>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<IList<TEntity>> GetListIsDeletedAsync(string emailKey, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.GetListIsDeleted;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IList<TEntity>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<IList<TEntity>> GetListIsNotDeletedAsync(string emailKey, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.GetListIsNotDeleted;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<IList<TEntity>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<int> CountAllAsync(string emailKey, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.CountAll;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return -1;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return -1;
        }
    }

    public virtual async Task<int> CountIsDeletedAsync(string emailKey, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.CountIsDeleted;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return -1;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return -1;
        }
    }
    public virtual async Task<int> CountIsNotDeletedAsync(string emailKey, string clientName, string accessToken = "")
    {
        try
        {
            var url = this._entityUrl + BaseMethodUrl.CountIsNotDeleted;

            var httpClient = this.CreateClient(emailKey, clientName, accessToken);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return -1;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return -1;
        }
    }
    #endregion

    #region [ Private Methods -  ]
    protected HttpClient CreateClient(string emailKey, string clientName = "HrClient", string accessToken = "")
    {
        var result = this._httpClientFactory.CreateClient(clientName);

        if (!string.IsNullOrEmpty(accessToken))
        {
            var decryptedAccessToken = this._encriptionProvider.DecryptWithSalt(accessToken, emailKey);
            result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", decryptedAccessToken);
        }

        return result;
    }

    protected StringContent GetJsonPayload<TPayload>(TPayload payload)
    {
        return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
    }
    #endregion
}
