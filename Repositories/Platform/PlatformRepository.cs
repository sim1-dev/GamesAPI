using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using GamesAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories;
public class PlatformRepository : IPlatformRepository {
    private readonly BaseContext _db;
    public PlatformRepository(BaseContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<Platform>> GetAll() {
        return await _db.Platforms.ToListAsync();
    }

    public async Task<Platform?> Find(int id) {
        Platform? platform = await _db.Platforms
            .Include(platform => platform.Games)
        .FirstOrDefaultAsync(platform => platform.Id == id);

        return platform;
    }

    public async Task<Platform?> FindByName(string name) {
        Platform? platform = await _db.Platforms.FirstOrDefaultAsync(p => p.Name == name);

        return platform;
    }

    public async Task<IEnumerable<Platform>> FindByIds(List<int> ids) {
        return await _db.Platforms.Where(platform => ids.Contains(platform.Id)).ToListAsync();
    }
    public async Task Create(Platform platform) {
        await _db.Platforms.AddAsync(platform);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Platform platform) {
        _db.Entry(platform).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Platform platform) {
        _db.Platforms.Remove(platform);
        await _db.SaveChangesAsync();
    }

}