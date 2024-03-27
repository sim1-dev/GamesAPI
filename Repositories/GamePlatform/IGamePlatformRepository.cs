using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface IGamePlatformRepository : IPivotRepository<GamePlatform> {
    public Task<IEnumerable<GamePlatform>> GetForGame(int gameId);
    public Task<IEnumerable<GamePlatform>> GetForPlatform(int platformId);
    Task DeleteRange(IEnumerable<GamePlatform> gamePlatforms);
}