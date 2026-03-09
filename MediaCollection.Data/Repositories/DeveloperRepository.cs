namespace MediaCollection.Data.Repositories;

/// <summary>
/// The repository pattern for <see cref="Developer"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class DeveloperRepository : EFRepository<Developer>, IDeveloperRepository
{
    /// <summary>
    /// Initializes the repository
    /// </summary>
    /// <param name="mediaDbContext">The EF data context.</param>
    public DeveloperRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    /// <summary>
    /// Enters a singular developer entity into the database.
    /// </summary>
    public override async Task CreateRecord(Developer entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecord(entity, cancellationToken);
    }

    /// <summary>
    /// Enters multiple developer entities into the database.
    /// </summary>
    public override async Task CreateRecords(IEnumerable<Developer> entities, CancellationToken cancellationToken = default)
    {
        await base.CreateRecords(entities, cancellationToken);
    }

    /// <summary>
    /// Delete a developer record.
    /// </summary>
    public override async Task DeleteRecord(Developer entity)
    {
        await base.DeleteRecord(entity);
    }

    /// <summary>
    /// Returns all the developer records from the database.
    /// </summary>
    public override async Task<IQueryable<Developer>> Get()
    {
        return await base.Get();
    }

    /// <summary>
    /// Returns a record based on the id from the database.
    /// </summary>
    /// <param name="id">The id of the developer.</param>
    /// <returns>The developer.</returns>
    public override async Task<Developer> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.Get(id, cancellationToken) ?? throw new RecordNotFoundException($"No developer with id {id} was found.");
    }

    /// <summary>
    /// Save changes to the database.
    /// </summary>
    public override async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await base.SaveChanges(cancellationToken);
    }
}
