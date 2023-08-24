using SharedLibrary.EntityProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLibrary.EntityProviders;

public interface IBaseProvider<TEntity> 
    where TEntity : BaseEntity
{
    #region [ Public Methods - CRUD ]
    Task<bool> AddAsync(TEntity entity);

    Task<TEntity> GetSingleByIdAsync(string id);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> SoftDeleteAsync(string entityId);

    Task<bool> RecoverAsync(string entityId);

    Task<bool> DestroyAsync(string entityId);

    Task<IList<TEntity>> GetListAllAsync();

    Task<IList<TEntity>> GetListIsDeletedAsync();

    Task<IList<TEntity>> GetListIsNotDeletedAsync();

    Task<int> CountAllAsync();

    Task<int> CountIsDeletedAsync();

    Task<int> CountIsNotDeletedAsync();
    #endregion
}
