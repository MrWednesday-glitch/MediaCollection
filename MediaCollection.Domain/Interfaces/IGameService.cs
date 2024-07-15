using MediaCollection.Domain.Entities;

namespace MediaCollection.Domain.Interfaces;

// TODO Make summaries
public interface IGameService
{
    IEnumerable<Game> Get();

    Game Get(int id);
}
