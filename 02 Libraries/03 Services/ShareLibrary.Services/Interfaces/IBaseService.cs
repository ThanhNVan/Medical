using ShareLibrary.EntityProviders;

namespace ShareLibrary.Services;

public interface IBaseService<TEntity> : IBaseProvider<TEntity>
    where TEntity : BaseEntity
{
}
