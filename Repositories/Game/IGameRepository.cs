using GamesAPI.Core.Models;
using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface IGameRepository : IRepository<Game> {
    //public Task<Game?> FindByName(string name);
}