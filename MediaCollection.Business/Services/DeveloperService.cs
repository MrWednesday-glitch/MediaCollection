using MediaCollection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Business.Services;

// TODO Summaries
// TODO Unit testen
public class DeveloperService : IDeveloperService
{
    private readonly IDeveloperRepository _developerRepository;

    public DeveloperService(IDeveloperRepository developerRepository)
    {
        ArgumentNullException.ThrowIfNull(developerRepository);

        _developerRepository = developerRepository;
    }

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

    private async Task<IQueryable<Developer>> FilterOutExisting(IEnumerable<DeveloperToBe> developersToBe)
    {
        IEnumerable<string> developersNamesToCheck = developersToBe
            .Select(dTB => dTB.Name);

        IQueryable<Developer> existingDevelopers = (await _developerRepository.Get())
            .Where(d => developersNamesToCheck.Contains(d.Name));

        return existingDevelopers;
    }
}
