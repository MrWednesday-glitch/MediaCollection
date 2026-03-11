namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class GameRepository : EFRepository<Game>, IGameRepository
{
    public GameRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecordAsync(Game entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordAsync(entity, cancellationToken);
    }

    public override async Task DeleteRecordAsync(Game entity)
    {
        await base.DeleteRecordAsync(entity);
    }

    public override async Task<IQueryable<Game>> GetAsync()
    {
        return await base.GetAsync();
    }

    public override async Task<Game> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new RecordNotFoundException($"No game with id {id} was found.");
    }

    public override async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}
