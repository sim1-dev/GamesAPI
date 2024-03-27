using GamesAPI.Models;
using GamesAPI.Repositories;

namespace GamesAPI.Services;

public class GamePlatformService : IGamePlatformService {

    private readonly IGamePlatformRepository _gamePlatformRepository;

    public GamePlatformService(IGamePlatformRepository gamePlatformRepository) {
       this._gamePlatformRepository = gamePlatformRepository;
    }

    public async Task<GamePlatform> Create(int gameId, int platformId) {
        GamePlatform gamePlatform = new GamePlatform() {
            GameId = gameId,
            PlatformId = platformId
        };
        
        await this._gamePlatformRepository.Create(gamePlatform);

        return gamePlatform;
    }

    public async Task<bool> DeleteForGame(int gameId) {
        IEnumerable<GamePlatform> gamePlatforms = await this._gamePlatformRepository.GetForGame(gameId);

        if(gamePlatforms is null)
            return false;

        await this._gamePlatformRepository.DeleteRange(gamePlatforms);

        return true;
    }

    public async Task<bool> DeleteForPlatform(int platformId) {
        IEnumerable<GamePlatform> gamePlatforms = await this._gamePlatformRepository.GetForPlatform(platformId);

        if(gamePlatforms is null)
            return false;

        await this._gamePlatformRepository.DeleteRange(gamePlatforms);

        return true;
    }
}