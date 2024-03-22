using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories;
public class SoftwareHouseRepository : ISoftwareHouseRepository {
    private readonly BaseContext _db;
    public SoftwareHouseRepository(BaseContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<SoftwareHouse>> GetAll() {
        return await _db.SoftwareHouses.ToListAsync();
    }

    public async Task<SoftwareHouse?> Find(int id) {
        SoftwareHouse? softwareHouse = await _db.SoftwareHouses
            .Include(softwareHouse => softwareHouse.Developers)
        .FirstOrDefaultAsync(softwareHouse => softwareHouse.Id == id);

        return softwareHouse;
    }

    public async Task<SoftwareHouse?> FindByName(string name) {
        SoftwareHouse? softwareHouse = await _db.SoftwareHouses.FirstOrDefaultAsync(p => p.Name == name);

        return softwareHouse;
    }

    public async Task Create(SoftwareHouse softwareHouse) {
        await _db.SoftwareHouses.AddAsync(softwareHouse);
        await _db.SaveChangesAsync();
    }

    public async Task Update(SoftwareHouse softwareHouse) {
        _db.Entry(softwareHouse).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(SoftwareHouse softwareHouse) {
        _db.SoftwareHouses.Remove(softwareHouse);
        await _db.SaveChangesAsync();
    }

}