namespace MediaCollection.Data.Repositories;

public class FilmRepository : EFRepository<Film>, IFilmRepository
{
    public FilmRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Film entity)
    {
        await base.CreateRecord(entity);
    }

    public override async Task DeleteRecord(Film entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Film>> Get()
    {
        return await base.Get();
    }

    public override async Task<Film> Get(int id)
    {
        return await base.Get(id) ?? throw new KeyNotFoundException($"No film with id {id} was found.");
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
