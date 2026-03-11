using MediaCollection.Domain.Models;

namespace MediaCollection.Domain.Interfaces;

/// <summary>
/// The interface for the service class of the <see cref="Publisher"/> entity.
/// </summary>
public interface IPublisherService
{
    /// <summary>
    /// The promise of the logic that needs to happen before the <see cref="PublisherToBe"/> objects can be stored into the database.
    /// </summary>
    /// <param name="publishersToBe">The objects that potentially need to be stored into the database.</param>
    /// <returns>The existing records out of the database.</returns>
    Task<CustomResult<IEnumerable<Publisher>>> AddAsync(IEnumerable<PublisherToBe> publishersToBe, CancellationToken cancellationToken = default);
}
