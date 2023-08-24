﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShareLibrary.EntityProviders;
using ShareLibrary.DataProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLibrary.DataProviders;

public abstract class BaseDataProvider<TEntity, TContext> : IBaseDataProvider<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    #region [ Fields ]
    protected readonly ILogger<BaseDataProvider<TEntity, TContext>> _logger;

    protected readonly IDbContextFactory<TContext> _dbContextFactory;

    protected readonly IEncriptionProvider _encriptionProvider; 
    #endregion

    #region [ CTor ]
    public BaseDataProvider(ILogger<BaseDataProvider<TEntity, TContext>> logger, IDbContextFactory<TContext> dbContextFactory,
        IEncriptionProvider encriptionProvider) {
        this._logger = logger;
        this._dbContextFactory = dbContextFactory;
        this._encriptionProvider = encriptionProvider;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    public async virtual Task<bool> AddAsync(TEntity entity) {
        try {
            using var context = await this.GetContextAsync();
            if (await context.Set<TEntity>().FindAsync(entity.Id) != null) {
                this._logger.LogWarning($"Duplicated {nameof(TEntity)}");
                return false;
            }

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<TEntity> GetSingleByIdAsync(string id) {
        var result = default(TEntity);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async virtual Task<bool> UpdateAsync(TEntity entity) {
        try {
            using var context = await this.GetContextAsync();
            entity.LastUpdatedAt = DateTime.UtcNow;
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return true;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> SoftDeleteAsync(string entityId) {
        try {
            using var context = await this.GetContextAsync();
            var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (dbResult == null) {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }
            dbResult.LastUpdatedAt = DateTime.UtcNow;
            dbResult.IsDeleted = true;
            context.Set<TEntity>().Update(dbResult);
            await context.SaveChangesAsync();
            return true;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> RecoverAsync(string entityId) {
        try {
            using var context = await this.GetContextAsync();
            var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (dbResult == null) {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }
            dbResult.LastUpdatedAt = DateTime.UtcNow;
            dbResult.IsDeleted = false;
            context.Set<TEntity>().Update(dbResult);
            await context.SaveChangesAsync();
            return true;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> DestroyAsync(string entityId) {
        try {
            using var context = await  this.GetContextAsync();
            var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (dbResult == null) {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }
            context.Set<TEntity>().Remove(dbResult);
            await context.SaveChangesAsync();
            return true;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<IList<TEntity>> GetListAllAsync() {
        var result = default(IList<TEntity>);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().OrderByDescending(x => x.IsDeleted).ToListAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async virtual Task<IList<TEntity>> GetListIsDeletedAsync() {
        var result = default(IList<TEntity>);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == true).OrderByDescending(x => x.LastUpdatedAt).ToListAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    public async virtual Task<IList<TEntity>> GetListIsNotDeletedAsync() {
        var result = default(IList<TEntity>);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == false).OrderByDescending(x => x.LastUpdatedAt).ToListAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async virtual Task<int> CountAllAsync() {
        var result = default(int);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().CountAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    public async virtual Task<int> CountIsDeletedAsync() {
        var result = default(int);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == true).CountAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    public async virtual Task<int> CountIsNotDeletedAsync() {
        var result = default(int);
        try {
            using var context = await this.GetContextAsync();
            result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == false).CountAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion

    #region [ Methods - Without TContext ]
    public async virtual Task<bool> AddAsync(TEntity entity, TContext context)
    {
        try
        {

            if (await context.Set<TEntity>().FindAsync(entity.Id) != null)
            {
                this._logger.LogWarning($"Duplicated {nameof(TEntity)}");
                return false;
            }

            await context.AddAsync(entity);
            return true;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity, TContext context)
    {
        try
        {
            if (await context.Set<TEntity>().FindAsync(entity.Id) != null)
            {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }

            entity.LastUpdatedAt = DateTime.UtcNow;
            context.Set<TEntity>().Update(entity);
            return true;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> SoftDeleteAsync(string entityId, TContext context)
    {
        try
        {
            var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (dbResult == null)
            {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }
            dbResult.LastUpdatedAt = DateTime.UtcNow;
            dbResult.IsDeleted = true;
            context.Set<TEntity>().Update(dbResult);
            return true;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> RecoverAsync(string entityId, TContext context)
    {
        try
        {
            var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (dbResult == null)
            {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }
            dbResult.LastUpdatedAt = DateTime.UtcNow;
            dbResult.IsDeleted = false;
            context.Set<TEntity>().Update(dbResult);
            return true;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> DestroyAsync(string entityId, TContext context)
    {
        try
        {
            var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (dbResult == null)
            {
                this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                return false;
            }
            context.Set<TEntity>().Remove(dbResult);
            return true;
        } catch (Exception ex)
        {
            this._logger.LogError(ex.Message);
            return false;
        }
    }
    #endregion

    #region [ Private Methods - TContext ]
    public async Task<TContext> GetContextAsync() {
        return await this._dbContextFactory.CreateDbContextAsync();
    }

    public async Task SaveChangedAsync(TContext context)
    {
        await context.SaveChangesAsync();
    }
    #endregion
}
