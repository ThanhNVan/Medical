using System.Collections.Generic;
using System.Threading.Tasks;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IBaseHrHttpClientProviders<TEntity>
    where TEntity : BaseEntity
{
    #region [ Methods -  ]
    Task<bool> AddAsync(TEntity entity);

    Task<TEntity> GetSingleByIdAsync(string id);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> SoftDeleteAsync(string entityId);

    Task<bool> DestroyAsync(string entityId);

    Task<bool> RecoverAsync(string entityId);

    Task<IList<TEntity>> GetListAllAsync();

    Task<IList<TEntity>> GetListIsDeletedAsync();

    Task<IList<TEntity>> GetListIsNotDeletedAsync();

    Task<int> CountAllAsync();

    Task<int> CountIsDeletedAsync();

    Task<int> CountIsNotDeletedAsync();
    #endregion
}
