using Microsoft.EntityFrameworkCore;
using ShareLibrary.DataProviders;
using ShareLibrary.EntityProviders;

namespace ShareLibrary.LogicProviders;

public interface IBaseLogicProvider<TEntity, TContext> : IBaseDataProvider<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
{
}
