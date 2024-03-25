using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface IGamePlatformRepository : IPivotRepository<GamePlatform> {
    public Task<IEnumerable<GamePlatform>> GetAllForGame(int gameId);
    public Task<IEnumerable<GamePlatform>> GetAllForPlatform(int platformId);
    Task DeleteRange(IEnumerable<GamePlatform> gamePlatforms);
}