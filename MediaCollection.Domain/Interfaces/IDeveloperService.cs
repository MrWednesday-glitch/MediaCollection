using MediaCollection.Domain.Models;

namespace MediaCollection.Domain.Interfaces;

/// <summary>
/// The interface for the service class of the <see cref="Developer"/> entity.
/// </summary>
public interface IDeveloperService
{
    /// <summary>
    /// The promise of the logic that needs to happen before the <see cref="DeveloperToBe"/> objects can be stored into the database.
    /// </summary>
    /// <param name="developersToBe">The objects that potentially need to be stored into the database.</param>
    /// <returns>The existing records out of the database.</returns>
    Task<CustomResult<IEnumerable<Developer>>> Add(IEnumerable<DeveloperToBe> developersToBe, CancellationToken cancellationToken = default);
}
