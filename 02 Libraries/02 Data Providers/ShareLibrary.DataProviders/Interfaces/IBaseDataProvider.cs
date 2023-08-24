using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.Threading.Tasks;

namespace ShareLibrary.DataProviders;

public interface IBaseDataProvider<TEntity, TContext> : IBaseProvider<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{

    #region [ Methods - Wtihout TContext ]
    Task<bool> AddAsync(TEntity entity, TContext context);

    Task<bool> UpdateAsync(TEntity entity, TContext context);

    Task<bool> SoftDeleteAsync(string entityId, TContext context);

    Task<bool> RecoverAsync(string entityId, TContext context);

    Task<bool> DestroyAsync(string entityId, TContext context);
    #endregion

    #region [ Methods - TContext ]
    Task<TContext> GetContextAsync();

    Task SaveChangedAsync(TContext context);
    #endregion
}
