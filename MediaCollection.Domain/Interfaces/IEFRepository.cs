using MediaCollection.Domain.Entities;

namespace MediaCollection.Domain.Interfaces;

public interface IEFRepository<TEntity> where TEntity : EntityBase
{
    Task DeleteRecord(TEntity entity);

    Task<IQueryable<TEntity>> Get();

    Task<TEntity> Get(int id);

    Task CreateRecord(TEntity entity);

    Task SaveChanges();
}
