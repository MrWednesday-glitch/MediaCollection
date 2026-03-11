namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class FilmRepository : EFRepository<Film>, IFilmRepository
{
    public FilmRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecordAsync(Film entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordAsync(entity, cancellationToken);
    }

    public override async Task DeleteRecordAsync(Film entity)
    {
        await base.DeleteRecordAsync(entity);
    }

    public override async Task<IQueryable<Film>> GetAsync()
    {
        return await base.GetAsync();
    }

    public override async Task<Film> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new RecordNotFoundException($"No film with id {id} was found.");
    }

    public override async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}
