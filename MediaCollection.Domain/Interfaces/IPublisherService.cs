using MediaCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Interfaces;

// TODO Add summary
public interface IPublisherService
{
    Task<Publisher[]> Add(PublisherToBe[] publishersToBe);
}
