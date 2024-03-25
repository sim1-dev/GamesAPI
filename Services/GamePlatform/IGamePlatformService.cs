using GamesAPI.Models;
using GamesAPI.Core.Services;

namespace GamesAPI.Services;

public interface IGamePlatformService : IPivotService<GamePlatform> {
    public Task<bool> DeleteForGame(int gameId);
    public Task<bool> DeleteForPlatform(int platformId);
}