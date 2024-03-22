using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface IPlatformRepository : IRepository<Platform> {
    public Task<Platform?> FindByName(string name);
}