using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Repositories;
public class SoftwareHouseRepository : ISoftwareHouseRepository {

    private readonly IRepositoryHelper<SoftwareHouse> _repositoryHelper;
    private readonly BaseContext _db;
    public SoftwareHouseRepository(BaseContext db, IRepositoryHelper<SoftwareHouse> repositoryHelper) {
        this._db = db;
        this._repositoryHelper = repositoryHelper;
    }

    public async Task<IEnumerable<SoftwareHouse>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IQueryable<SoftwareHouse> softwareHousesQuery = _db.SoftwareHouses;

        softwareHousesQuery = _repositoryHelper.ApplyFilters(softwareHousesQuery, filters);
        softwareHousesQuery = _repositoryHelper.ApplyOrder(softwareHousesQuery, order);
        softwareHousesQuery = _repositoryHelper.ApplyPagination(softwareHousesQuery, pagination);

        return await softwareHousesQuery.ToListAsync();
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