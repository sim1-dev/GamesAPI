using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Repositories;
public class DeveloperRepository : IDeveloperRepository {
    private readonly BaseContext _db;
    private readonly IRepositoryHelper<Developer> _repositoryHelper;

    public DeveloperRepository(BaseContext db, IRepositoryHelper<Developer> repositoryHelper) {
        this._db = db;
        this._repositoryHelper = repositoryHelper;
    }

    public async Task<IEnumerable<Developer>> Get(RequestFilter[]? filters, RequestOrder? order) {
        IQueryable<Developer> developersQuery = _db.Developers;

        developersQuery = this._repositoryHelper.ApplyFilters(developersQuery, filters);
        developersQuery = this._repositoryHelper.ApplyOrder(developersQuery, order);

        return await developersQuery.ToListAsync();
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