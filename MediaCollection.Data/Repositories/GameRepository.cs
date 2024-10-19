using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class GameRepository : EFRepository<Game>, IGameRepository
{
    public GameRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Game entity)
    {
        await base.CreateRecord(entity);
    }

    public override async Task DeleteRecord(Game entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Game>> Get()
    {
        return await base.Get();
    }

    public override async Task<Game> Get(int id)
    {
        return await base.Get(id) ?? throw new KeyNotFoundException($"No game with id {id} was found.");
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
