using MediaCollection.Domain.Models;

namespace MediaCollection.Business.Services;

// TODO unit test
/// <summary>
/// The actual logic dealing with the <see cref="Publisher"/> entity
/// </summary>
public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        ArgumentNullException.ThrowIfNull(publisherRepository);

        _publisherRepository = publisherRepository;
    }

    /// <summary>
    /// Checks if the collection to be added isn't empty,
    /// that all the elements in it are unique,
    /// whether certain elements aren't in the database already,
    /// and then stores the unstored ones into the database.
    /// </summary>
    /// <param name="publishersToBe">The collection of publishers that are to be added.</param>
    /// <returns>The publisher entities that are in the database.</returns>
    public async Task<IEnumerable< Publisher>> Add(IEnumerable< PublisherToBe> publishersToBe)
    {
        if (publishersToBe.Count() <= 0)
        {
            return Array.Empty<Publisher>();
        }

        IEnumerable<PublisherToBe> distinctPublishersToBe = publishersToBe.DistinctBy(pTB => pTB.Name);

        IQueryable<Publisher> existingPublishers = await FilterOutExisting(distinctPublishersToBe);

        IEnumerable< Publisher> publishers = distinctPublishersToBe
            .Where(pTB => !existingPublishers.Any(p => p.Name.Equals(pTB.Name)))
            .Select(pTB => new Publisher 
            { 
                Name = pTB.Name, 
                PictureUri = pTB.PictureUri 
            });

        await _publisherRepository.CreateRecords(publishers);
        await _publisherRepository.SaveChanges();

        publishers = publishers.Concat(existingPublishers);

        return publishers;
    }

    /// <summary>
    /// Returns a collection of <see cref="Publisher"/> that already exists in the database.
    /// </summary>
    /// <param name="publishersToBe">The collection of publishers that are to be added.</param>
    /// <returns>A collection of already existing <see cref="Publisher"/> entities.</returns>
    private async Task<IQueryable<Publisher>> FilterOutExisting(IEnumerable<PublisherToBe> publishersToBe)
    {
        IEnumerable<string> publisherNamesToCheck = publishersToBe
            .Select(pTB => pTB.Name);

        IQueryable<Publisher> existingPublishers = (await _publisherRepository.Get())
            .Where(p => publisherNamesToCheck.Contains(p.Name));

        return existingPublishers;
    }
}
