using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories;
public class DeveloperRepository : IDeveloperRepository {
    private readonly BaseContext _db;
    public DeveloperRepository(BaseContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<Developer>> GetAll() {
        return await _db.Developers.ToListAsync();
    }

    public async Task<IEnumerable<Developer>> GetByUserId(int userId) {
        return await _db.Developers
            .Where(x => x.UserId == userId)
        .ToListAsync();
    }

    public async Task<Developer?> Find(int id) {
        Developer? developer = await _db.Developers
            .Include(developer => developer.User)
            .Include(developer => developer.SoftwareHouse)
        .FirstOrDefaultAsync(developer => developer.Id == id);

        return developer;
    }
    public async Task Create(Developer developer) {
        await _db.Developers.AddAsync(developer);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Developer developer) {
        _db.Entry(developer).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Developer developer) {
        _db.Developers.Remove(developer);
        await _db.SaveChangesAsync();
    }

}