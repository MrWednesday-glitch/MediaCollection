namespace MediaCollection.Domain.Interfaces;

/// <summary>
/// The generic interface for interacting with the <see cref="IRepository{TEntity}"/>. 
/// </summary>
/// <typeparam name="TEntity">The entities that are stored in the database via Entity Framework.</typeparam>
public interface IRepository<TEntity> where TEntity : EntityBase
{
    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity that needs to be deleted.</param>
    Task DeleteRecord(TEntity entity);

    /// <summary>
    /// Retrieves all the records from the database of type TEntity.
    /// </summary>
    /// <returns>A collection of entities.</returns>
    Task<IQueryable<TEntity>> Get();

    /// <summary>
    /// Retrieves an existing record from the database as an entity object.
    /// </summary>
    /// <param name="id">the id that corresponds with a record.</param>
    /// <returns>The record as an object of type TEntity.</returns>
    Task<TEntity> Get(Guid id);

    /// <summary>
    /// Adds a created entity to the database to become a record.
    /// </summary>
    /// <param name="entity">The entity that needs to be stored into the database.</param>
    Task CreateRecord(TEntity entity);

    /// <summary>
    /// Sends a previous command to the database to be executed.
    /// </summary>
    Task SaveChanges();

    /// <summary>
    /// Adds a multitude of <see cref="TEntity"/> entities to the database to become records.
    /// </summary>
    /// <param name="entities">The entities that need to be stored into the database.</param>
    Task CreateRecords(IEnumerable<TEntity> entities);
}
