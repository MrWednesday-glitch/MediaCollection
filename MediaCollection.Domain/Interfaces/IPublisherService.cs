using MediaCollection.Domain.Models;

namespace MediaCollection.Domain.Interfaces;

// TODO Add summary
public interface IPublisherService
{
    Task<Publisher[]> Add(PublisherToBe[] publishersToBe);
}
