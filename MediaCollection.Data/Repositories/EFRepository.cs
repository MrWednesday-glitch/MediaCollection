namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly MediaDbContext _mediaDbContext;

    public EFRepository(MediaDbContext mediaDbContext)
    {
        _mediaDbContext = mediaDbContext;
    }

    public virtual async Task CreateRecordAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _mediaDbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public virtual async Task CreateRecordsAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _mediaDbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public virtual async Task DeleteRecordAsync(TEntity entity)
    {
        _mediaDbContext.Set<TEntity>().Remove(entity);
    }

    public virtual async Task<IQueryable<TEntity>> GetAsync()
    {
        return _mediaDbContext.Set<TEntity>().AsQueryable();
    }

    public virtual async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return (await _mediaDbContext.Set<TEntity>().FindAsync(id, cancellationToken))!;
    }

    public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediaDbContext.SaveChangesAsync(cancellationToken);
    }
}
