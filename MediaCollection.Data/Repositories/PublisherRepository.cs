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
    public override async Task CreateRecordAsync(Publisher entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Delete a <see cref="Publisher"/> record.
    /// </summary>
    public override async Task DeleteRecordAsync(Publisher entity)
    {
        await base.DeleteRecordAsync(entity);
    }

    /// <summary>
    /// Returns all the <see cref="Publisher"/> records from the database.
    /// </summary>
    public override async Task<IQueryable<Publisher>> GetAsync()
    {
        return await base.GetAsync();
    }

    /// <summary>
    /// Returns a record based on the id from the database.
    /// </summary>
    /// <param name="id">The id of the publisher.</param>
    /// <returns>The publisher.</returns>
    public override async Task<Publisher> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new RecordNotFoundException($"No publisher with id {id} was found.");
    }

    /// <summary>
    /// Save changes to the database.
    /// </summary>
    public override async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Enters multiple developer entities into the database.
    /// </summary>
    public override async Task CreateRecordsAsync(IEnumerable<Publisher> entities, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordsAsync(entities, cancellationToken);
    }
}
