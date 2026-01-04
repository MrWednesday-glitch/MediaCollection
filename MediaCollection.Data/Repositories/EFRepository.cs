using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly MediaDbContext _mediaDbContext;

    public EFRepository(MediaDbContext mediaDbContext)
    {
        _mediaDbContext = mediaDbContext;
    }

    public virtual async Task CreateRecord(TEntity entity)
    {
        await _mediaDbContext.Set<TEntity>().AddAsync(entity);
    }

    public virtual async Task CreateRecords(IEnumerable<TEntity> entities)
    {
        await _mediaDbContext.Set<TEntity>().AddRangeAsync(entities);
    }

    public virtual async Task DeleteRecord(TEntity entity)
    {
        _mediaDbContext.Set<TEntity>().Remove(entity);
    }

    public virtual async Task<IQueryable<TEntity>> Get()
    {
        return _mediaDbContext.Set<TEntity>().AsQueryable();
    }

    public virtual async Task<TEntity> Get(Guid id)
    {
        return (await _mediaDbContext.Set<TEntity>().FindAsync(id))!;
    }

    public virtual async Task SaveChanges()
    {
        await _mediaDbContext.SaveChangesAsync();
    }
}
