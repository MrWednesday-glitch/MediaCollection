using MediaCollection.Domain.Models;

namespace MediaCollection.Business.Services;

// TODO unit test
// TODO Summaries
public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        ArgumentNullException.ThrowIfNull(publisherRepository);

        _publisherRepository = publisherRepository;
    }

    public async Task<Publisher[]> Add(PublisherToBe[] publishersToBe)
    {
        if (publishersToBe.Length <= 0)
        {
            return Array.Empty<Publisher>();
        }

        IEnumerable<PublisherToBe> distinctPublishersToBe = publishersToBe.DistinctBy(x => x.Name);

        IQueryable<Publisher> existingPublishers = await FilterOutExisting(distinctPublishersToBe);

        Publisher[] publishers = distinctPublishersToBe
            .Where(p => !existingPublishers.Any(e => e.Name.Equals(p.Name)))
            .Select(x => new Publisher { Name = x.Name, PictureUri = x.PictureUri })
            .ToArray();

        await _publisherRepository.CreateRecords(publishers);
        await _publisherRepository.SaveChanges();

        publishers = publishers.Concat(existingPublishers).ToArray();

        return publishers;
    }

    private async Task<IQueryable<Publisher>> FilterOutExisting(IEnumerable<PublisherToBe> publishersToBe)
    {
        IEnumerable<string> publisherNamesToCheck = publishersToBe
            .Select(x => x.Name);

        IQueryable<Publisher> existingPublishers = (await _publisherRepository.Get())
            .Where(p => publisherNamesToCheck.Contains(p.Name));

        return existingPublishers;
    }
}
