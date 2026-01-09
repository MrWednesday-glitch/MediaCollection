using MediaCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Interfaces;

// TODO Summaries
public interface IDeveloperService
{
    Task<IEnumerable<Developer>> Add(IEnumerable<DeveloperToBe> developersToBe);
}
