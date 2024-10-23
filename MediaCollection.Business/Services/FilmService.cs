namespace MediaCollection.Business.Services;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;

    public FilmService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository ?? throw new ArgumentNullException(nameof(filmRepository));
    }

    public async Task<(IEnumerable<Film>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        var filmCollection = await _filmRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            // TODO add logic to search through books
        }

        var totalItemCount = filmCollection.Count();
        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        var films = filmCollection
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();

        return (films, paginationMetadata);
    }

    public async Task<Film> Get(Guid id)
    {
        return await _filmRepository.Get(id);
    }
}
