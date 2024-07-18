using MediaCollection.Domain.Entities;

namespace MediaCollection.Domain.Interfaces;

// TODO Make summaries
public interface IGameService
{
    Task<(IEnumerable<Game>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "");

    Game Get(int id);
}
