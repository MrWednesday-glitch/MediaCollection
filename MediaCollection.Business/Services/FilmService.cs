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
        IQueryable<Film> filmCollection = await _filmRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm.ToLower();

            filmCollection = filmCollection.Where(film => film.Name.ToLower().Contains(searchTerm)
                                                           || film.Publisher.Name.ToLower().Contains(searchTerm)
                                                           || film.Director.Name.ToLower().Contains(searchTerm));
        }

       int totalItemCount = filmCollection.Count();
       PaginationMetadata paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

       List<Film> films = filmCollection
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
