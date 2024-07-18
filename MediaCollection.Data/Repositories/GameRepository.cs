using MediaCollection.Domain.Entities;
using MediaCollection.Domain.Interfaces;

namespace MediaCollection.Data.Repositories;

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
        try
        {
            return await base.Get(id);
        }
        catch (Exception ex)
        {

            throw; // Put the custom exception here and store the ex as an inner exception
        }
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
