using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface IDeveloperRepository : IRepository<Developer> {
    public Task<IEnumerable<Developer>> GetByUserId(int userId);
}