using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;

namespace GamesAPI.Services;

public class GamePlatformService {

    private readonly BaseContext _db;
    private readonly GameService _gameService;

    public GamePlatformService(BaseContext db, GameService gameService) {
       this._db = db;
       this._gameService = gameService;
    }

    // TODO rewrite

    // public async Task<Game?> AddPlatformToGame(Game game, Platform platform) {
    //     if(game.Platforms.Contains(platform))
    //         return game;

    //     game.Platforms.Add(platform);

    //     Game? updatedGame = await this._gameService.Update(game.Id, game);

    //     return updatedGame;
    // }

    // public async Task<Game?> RemovePlatformToGame(Game game, Platform platform) {
    //     if(!game.Platforms.Contains(platform))
    //         return game;

    //     game.Platforms.Remove(platform);

    //     Game? updatedGame = await this._gameService.Update(game.Id, game);

    //     return updatedGame;
    // }

}