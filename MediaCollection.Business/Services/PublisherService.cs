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


        throw new NotImplementedException();
    }
}
