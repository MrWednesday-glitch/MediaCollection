namespace MediaCollection.Data.Repositories;

/// <summary>
/// The repository pattern for <see cref="Publisher"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PublisherRepository : EFRepository<Publisher>, IPublisherRepository
{
    /// <summary>
    /// Initializes the repository
    /// </summary>
    /// <param name="mediaDbContext">The EF data context.</param>
    public PublisherRepository(MediaDbContext mediaDbContext) : base(mediaDbContext)
    {
    }

    /// <summary>
    /// Enters a singular <see cref="Publisher"/> entity into the database.
    /// </summary>
    public override async Task CreateRecord(Publisher entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecord(entity, cancellationToken);
    }

    /// <summary>
    /// Delete a <see cref="Publisher"/> record.
    /// </summary>
    public override async Task DeleteRecord(Publisher entity)
    {
        await base.DeleteRecord(entity);
    }

    /// <summary>
    /// Returns all the <see cref="Publisher"/> records from the database.
    /// </summary>
    public override async Task<IQueryable<Publisher>> Get()
    {
        return await base.Get();
    }

    /// <summary>
    /// Returns a record based on the id from the database.
    /// </summary>
    /// <param name="id">The id of the publisher.</param>
    /// <returns>The publisher.</returns>
    public override async Task<Publisher> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.Get(id, cancellationToken) ?? throw new RecordNotFoundException($"No publisher with id {id} was found.");
    }

    /// <summary>
    /// Save changes to the database.
    /// </summary>
    public override async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        await base.SaveChanges(cancellationToken);
    }

    /// <summary>
    /// Enters multiple developer entities into the database.
    /// </summary>
    public override async Task CreateRecords(IEnumerable<Publisher> entities, CancellationToken cancellationToken = default)
    {
        await base.CreateRecords(entities, cancellationToken);
    }
}
