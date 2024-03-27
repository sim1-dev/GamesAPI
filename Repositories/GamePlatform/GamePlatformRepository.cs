using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories;
public class GamePlatformRepository : IGamePlatformRepository {
    private readonly BaseContext _db;
    public GamePlatformRepository(BaseContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<GamePlatform>> GetForGame(int gameId) {
        return await _db.GamePlatforms
            .Where(x => x.GameId == gameId)
        .ToListAsync();
    }

    public async Task<IEnumerable<GamePlatform>> GetForPlatform(int platformId) {
        return await _db.GamePlatforms
            .Where(x => x.PlatformId == platformId)
        .ToListAsync();
    }

    public async Task Create(GamePlatform platform) {
        await _db.GamePlatforms.AddAsync(platform);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(GamePlatform platform) {
        _db.GamePlatforms.Remove(platform);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteRange(IEnumerable<GamePlatform> platforms) {
        _db.GamePlatforms.RemoveRange(platforms);
        await _db.SaveChangesAsync();
    }

}