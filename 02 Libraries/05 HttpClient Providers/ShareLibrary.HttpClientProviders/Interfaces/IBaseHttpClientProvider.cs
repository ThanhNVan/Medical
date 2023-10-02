using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareLibrary.HttpClientProviders;

public interface IBaseHttpClientProvider<TEntity>
    where TEntity : BaseEntity
{
    #region [ Public Methods - CRUD ]
    Task<bool> AddAsync(string emailKey, TEntity entity, string accessToken = "");

    Task<TEntity> GetSingleByIdAsync(string emailKey, string id, string accessToken = "");

    Task<bool> UpdateAsync(string emailKey, TEntity entity, string accessToken = "");

    Task<bool> SoftDeleteAsync(string emailKey, string entityId, string accessToken = "");

    Task<bool> RecoverAsync(string emailKey, string entityId, string accessToken = "");

    Task<bool> DestroyAsync(string emailKey, string entityId, string accessToken = "");

    Task<IList<TEntity>> GetListAllAsync(string emailKey, string accessToken = "");

    Task<IList<TEntity>> GetListIsDeletedAsync(string emailKey, string accessToken = "");

    Task<IList<TEntity>> GetListIsNotDeletedAsync(string emailKey, string accessToken = "");

    Task<int> CountAllAsync(string emailKey, string accessToken = "");

    Task<int> CountIsDeletedAsync(string emailKey, string accessToken = "");

    Task<int> CountIsNotDeletedAsync(string emailKey, string accessToken = "");
    #endregion
}
