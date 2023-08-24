using Microsoft.EntityFrameworkCore;
using SharedLibrary.DataProviders;
using SharedLibrary.EntityProviders;

namespace SharedLibrary.LogicProviders;

public interface IBaseLogicProvider<TEntity, TContext> : IBaseDataProvider<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext
{
}
