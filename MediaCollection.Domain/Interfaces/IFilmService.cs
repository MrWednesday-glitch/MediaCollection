namespace MediaCollection.Domain.Interfaces;

public interface IFilmService
{
    //TODO Write summary
    Task<(IEnumerable<Film>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "");

    // TODO Write Summary
    Task<Film> Get(int id);
}
