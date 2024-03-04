using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

public class PlatformService {

    private readonly BaseContext _db;

    public PlatformService(BaseContext db) {
       this._db = db;
    }

    public async Task<List<Platform>> GetAll() {
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

    public async Task<List<Platform>> FindByIds(List<int> ids) {
        return await _db.Platforms.Where(platform => ids.Contains(platform.Id)).ToListAsync();
    }

    public async Task<Platform> Create(Platform platform) {
        _db.Platforms.Add(platform);
        await _db.SaveChangesAsync();

        return platform;
    }

    public async Task<Platform?> Update(int id, Platform platform) {

        Platform? existingPlatform = await this.Find(id);

        if(existingPlatform is null)
            return null;

        this._db.Entry(existingPlatform).CurrentValues.SetValues(platform);

        await this._db.SaveChangesAsync();

        return existingPlatform;
    }

    public async Task<Platform?> Delete(int id) {
        Platform? platform = await this.Find(id);

        if(platform is null)
            return null;

        this._db.Platforms.Remove(platform);

        await this._db.SaveChangesAsync();

        return platform;
    }

}