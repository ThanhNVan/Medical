using Microsoft.EntityFrameworkCore;
using ShareLibrary.DataProviders;
using ShareLibrary.EntityProviders;

namespace ShareLibrary.LogicProviders;

public interface IBaseLogicProvider<TEntity> : IBaseProvider<TEntity>
    where TEntity : BaseEntity
{
}
