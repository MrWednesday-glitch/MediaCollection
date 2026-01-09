namespace MediaCollection.Business.Services;

// TODO Unit testen
/// <summary>
/// The actual logic dealing with the <see cref="Developer"/> entity.
/// </summary>
public class DeveloperService : IDeveloperService
{
    private readonly IDeveloperRepository _developerRepository;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    /// <param name="developerRepository">The implementation of the <see cref="IDeveloperRepository"/>.</param>
    public DeveloperService(IDeveloperRepository developerRepository)
    {
        ArgumentNullException.ThrowIfNull(developerRepository);

        _developerRepository = developerRepository;
    }

    /// <summary>
    /// Checks if the collection to be added isn't empty,
    /// that all the elements in it are unique,
    /// whether certain elements aren't in the database already,
    /// and then stores the unstored ones into the database.
    /// </summary>
    /// <param name="developersToBe">The collection of <see cref="Developer"/> that are to be added.</param>
    /// <returns>The <see cref="Developer"/> entities that are in the database.</returns>
    public async Task<IEnumerable<Developer>> Add(IEnumerable<DeveloperToBe> developersToBe)
    {
        if (!developersToBe.Any())
        {
            return Enumerable.Empty<Developer>();
        }

        IEnumerable<DeveloperToBe> distinctDevelopersToBe = developersToBe.DistinctBy(dTB => dTB.Name);

        IQueryable<Developer> existingDevelopers = await FilterOutExisting(distinctDevelopersToBe);

        IEnumerable<Developer> developers = distinctDevelopersToBe
            .Where(dTB => !existingDevelopers.Any(p => p.Name.Equals(dTB.Name)))
            .Select(dTB => new Developer
            {
                Name = dTB.Name,
                PictureUri = dTB.PictureUri
            });

        await _developerRepository.CreateRecords(developers);
        await _developerRepository.SaveChanges();

        developers = developers.Concat(existingDevelopers);

        return developers;
    }

    /// <summary>
    /// Returns a collection of <see cref="Developer"/> that already exists in the database.
    /// </summary>
    /// <param name="developersToBe">The collection of developers that are to be added.</param>
    /// <returns>A collection of already existing <see cref="Developer"/> entities.</returns>
    private async Task<IQueryable<Developer>> FilterOutExisting(IEnumerable<DeveloperToBe> developersToBe)
    {
        IEnumerable<string> developersNamesToCheck = developersToBe
            .Select(dTB => dTB.Name);

        IQueryable<Developer> existingDevelopers = (await _developerRepository.Get())
            .Where(d => developersNamesToCheck.Contains(d.Name));

        return existingDevelopers;
    }
}
