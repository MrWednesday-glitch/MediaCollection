using MediaCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            return [];
        }

        Publisher[] publishers = publishersToBe
            .Select(x => new Publisher { Name = x.Name, PictureUri = x.PictureUri })
            .ToArray();

        // TODO check if publisher already exists, and then remove it from the collection

        await _publisherRepository.CreateRecords(publishers);
        await _publisherRepository.SaveChanges();

        return publishers;
    }
}
