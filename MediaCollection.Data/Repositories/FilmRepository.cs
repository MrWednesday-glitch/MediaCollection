namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class FilmRepository : EFRepository<Film>, IFilmRepository
{
    public FilmRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Film entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecord(entity, cancellationToken);
    }

    public override async Task DeleteRecord(Film entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Film>> Get()
    {
        return await base.Get();
    }

    public override async Task<Film> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.Get(id, cancellationToken) ?? throw new RecordNotFoundException($"No film with id {id} was found.");
    }

    public override async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await base.SaveChanges(cancellationToken);
    }
}
