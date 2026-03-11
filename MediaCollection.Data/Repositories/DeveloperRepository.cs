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
    public override async Task CreateRecordAsync(Developer entity, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Enters multiple developer entities into the database.
    /// </summary>
    public override async Task CreateRecordsAsync(IEnumerable<Developer> entities, CancellationToken cancellationToken = default)
    {
        await base.CreateRecordsAsync(entities, cancellationToken);
    }

    /// <summary>
    /// Delete a developer record.
    /// </summary>
    public override async Task DeleteRecordAsync(Developer entity)
    {
        await base.DeleteRecordAsync(entity);
    }

    /// <summary>
    /// Returns all the developer records from the database.
    /// </summary>
    public override async Task<IQueryable<Developer>> GetAsync()
    {
        return await base.GetAsync();
    }

    /// <summary>
    /// Returns a record based on the id from the database.
    /// </summary>
    /// <param name="id">The id of the developer.</param>
    /// <returns>The developer.</returns>
    public override async Task<Developer> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new RecordNotFoundException($"No developer with id {id} was found.");
    }

    /// <summary>
    /// Save changes to the database.
    /// </summary>
    public override async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}
