using Microsoft.AspNetCore.Identity;

namespace MediaCollection.Business.Services;

// TODO Fix unit tests
/// <summary>
/// The implementation of the <see cref="IFilmService"/>.
/// </summary>
public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// Initializes the constructor.
    /// </summary>
    public FilmService(IFilmRepository filmRepository, UserManager<ApplicationUser> userManager)
    {
        ArgumentNullException.ThrowIfNull(filmRepository);
        ArgumentNullException.ThrowIfNull(userManager);

        _filmRepository = filmRepository;
        _userManager = userManager;
    }

    // TODO Change this to return CustomResult<IEnumerable<UserFilm>>
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<(CustomResult<IEnumerable<Film>>, PaginationMetadata)> GetAsync(
        string userEmail,
        int pageNumber, 
        int pageSize, 
        string? searchTerm = "",
        CancellationToken cancellationToken = default)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(userEmail);

        if (user is null)
        {
            return (CustomResult<IEnumerable<Film>>.Failure(CustomError.Unauthorized("No user found.")), new PaginationMetadata(0, 1, 1));
        }

        IQueryable<Film> filmCollection = (await _filmRepository.GetAsync())
            .Where(f => f.UserFilms.Any(uf => uf.UserId == user.Id));

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

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<CustomResult<Film>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            Film film = await _filmRepository.GetAsync(id, cancellationToken);

            return CustomResult<Film>.Success(film);
        }
        // TODO Unit test
        catch (RecordNotFoundException ex)
        {
            return CustomResult<Film>.Failure(CustomError.RecordNotFound(ex.Message));
        }
    }
}
