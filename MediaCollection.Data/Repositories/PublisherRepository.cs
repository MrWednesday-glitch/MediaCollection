using System.Diagnostics.CodeAnalysis;

namespace MediaCollection.Data.Repositories;

[ExcludeFromCodeCoverage]
public class PublisherRepository : EFRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Publisher entity)
    {
        await base.CreateRecord(entity);
    }

    public override async Task DeleteRecord(Publisher entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Publisher>> Get()
    {
        return await base.Get();
    }

    public override async Task<Publisher> Get(Guid id)
    {
        return await base.Get(id) ?? throw new KeyNotFoundException($"No publisher with id {id} was found.");
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }

    public override async Task CreateRecords(Publisher[] entities)
    {
        await base.CreateRecords(entities);
    }
}
