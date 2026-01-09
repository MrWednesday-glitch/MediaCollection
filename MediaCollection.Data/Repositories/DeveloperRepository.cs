using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Data.Repositories;

// TODO Summaries
[ExcludeFromCodeCoverage]
public class DeveloperRepository : EFRepository<Developer>, IDeveloperRepository
{
    public DeveloperRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    public override async Task CreateRecord(Developer entity)
    {
        await base.CreateRecord(entity);
    }

    public override async Task CreateRecords(IEnumerable<Developer> entities)
    {
        await base.CreateRecords(entities);
    }
    public override async Task DeleteRecord(Developer entity)
    {
        await base.DeleteRecord(entity);
    }

    public override async Task<IQueryable<Developer>> Get()
    {
        return await base.Get();
    }

    public override async Task<Developer> Get(Guid id)
    {
        return await base.Get(id) ?? throw new KeyNotFoundException($"No developer with id {id} was found.");
    }

    public override async Task SaveChanges()
    {
        await base.SaveChanges();
    }
}
