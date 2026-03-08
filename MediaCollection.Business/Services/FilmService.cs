namespace MediaCollection.Business.Services;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;

    public FilmService(IFilmRepository filmRepository)
    {
        ArgumentNullException.ThrowIfNull(filmRepository);

        _filmRepository = filmRepository;
    }

    public async Task<(CustomResult<IEnumerable<Film>>, PaginationMetadata)> Get(int pageNumber, int pageSize, string? searchTerm = "")
    {
        IQueryable<Film> filmCollection = await _filmRepository.Get();

        if (!searchTerm.IsNullOrEmpty())
        {
            searchTerm = searchTerm!.ToLower();

            filmCollection = filmCollection
                .TagWith("search")
                .Where(film => film.Name.ToLower().Contains(searchTerm)
                                || film.Publisher.Name.ToLower().Contains(searchTerm)
                                || film.Director.Name.ToLower().Contains(searchTerm));
        }

        int totalItemCount = filmCollection.Count();
        PaginationMetadata paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        List<Film> films = filmCollection
             .TagWith("get")
             .Skip(pageSize * (pageNumber - 1))
             .Take(pageSize)
             .ToList();

        return (CustomResult<IEnumerable<Film>>.Success(films), paginationMetadata);
    }

    public async Task<CustomResult<Film>> Get(Guid id)
    {
        try
        {
            Film film = await _filmRepository.Get(id);

            return CustomResult<Film>.Success(film);
        }
        // TODO Unit test
        catch (RecordNotFoundException ex)
        {
            return CustomResult<Film>.Failure(CustomError.RecordNotFound(ex.Message));
        }
    }
}
