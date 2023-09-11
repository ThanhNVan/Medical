using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.Repositories;
using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareLibrary.Services;

public abstract class BaseServices<TEntity, TRepository, TContext> : IBaseService<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
    where TRepository : IBaseRepository<TEntity, TContext>
{
    #region [ Fields ]
    protected readonly ILogger<BaseServices<TEntity, TRepository, TContext>> _logger;
    protected readonly TRepository _repository;
    protected readonly IEncriptionProvider _encriptionProvider;
    #endregion

    #region [ CTor ]
    public BaseServices(ILogger<BaseServices<TEntity, TRepository, TContext>> logger, TRepository dataProvider, IEncriptionProvider encriptionProvider)
    {
        this._logger = logger;
        this._repository = dataProvider;
        this._encriptionProvider = encriptionProvider;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    public async virtual Task<bool> AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            this._logger.LogWarning($"Null {nameof(TEntity)}");
            return false;
        }
        var result = await this._repository.AddAsync(entity);
        return result;
    }

    public async virtual Task<TEntity> GetSingleByIdAsync(string id)
    {
        var result = default(TEntity);
        if (string.IsNullOrEmpty(id))
        {
            this._logger.LogWarning($"IsNullOrEmpty: {nameof(TEntity)} Id");
            return result;
        }
        result = await this._repository.GetSingleByIdAsync(id);
        return result;
    }

    public async virtual Task<bool> UpdateAsync(TEntity entity)
    {
        var result = default(bool);
        if (string.IsNullOrEmpty(entity.Id))
        {
            this._logger.LogWarning($"IsNullOrEmpty: Id");
            return result;
        }
        result = await this._repository.UpdateAsync(entity);

        return result;
    }

    public async virtual Task<bool> SoftDeleteAsync(string entityId)
    {
        var result = default(bool);
        if (string.IsNullOrEmpty(entityId))
        {
            this._logger.LogWarning($"IsNullOrEmpty: entityId");
            return result;
        }
        result = await this._repository.SoftDeleteAsync(entityId);
        return result;
    }

    public async virtual Task<bool> RecoverAsync(string entityId)
    {
        var result = default(bool);
        if (string.IsNullOrEmpty(entityId))
        {
            this._logger.LogWarning($"IsNullOrEmpty: entityId");
            return result;
        }
        result = await this._repository.RecoverAsync(entityId);
        return result;
    }

    public async virtual Task<bool> DestroyAsync(string entityId)
    {
        var result = default(bool);
        if (string.IsNullOrEmpty(entityId))
        {
            this._logger.LogWarning($"IsNullOrEmpty: entityId");
            return result;
        }
        result = await this._repository.DestroyAsync(entityId);
        return result;
    }

    public async virtual Task<IList<TEntity>> GetListAllAsync()
    {
        var result = default(IList<TEntity>);

        result = await this._repository.GetListAllAsync();

        return result;

    }

    public async virtual Task<IList<TEntity>> GetListIsDeletedAsync()
    {
        var result = default(IList<TEntity>);

        result = await this._repository.GetListIsDeletedAsync();

        return result;
    }
    public async virtual Task<IList<TEntity>> GetListIsNotDeletedAsync()
    {
        var result = default(IList<TEntity>);

        result = await this._repository.GetListIsNotDeletedAsync();

        return result;
    }

    public async virtual Task<int> CountAllAsync()
    {
        var result = default(int);

        result = await this._repository.CountAllAsync();

        return result;
    }
    public async virtual Task<int> CountIsDeletedAsync()
    {
        var result = default(int);

        result = await this._repository.CountIsDeletedAsync();

        return result;
    }
    public async virtual Task<int> CountIsNotDeletedAsync()
    {
        var result = default(int);

        result = await this._repository.CountIsNotDeletedAsync();

        return result;
    }
    #endregion

    #region [ Methods - TContext ]
    public async Task<TContext> GetContextAsync()
    {
        return await this._repository.GetContextAsync();
    }

    public async Task SaveChangedAsync(TContext context)
    {
        await this._repository.SaveChangedAsync(context);
    }
    #endregion
}
