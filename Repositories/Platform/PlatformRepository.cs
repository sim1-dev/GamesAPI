using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Repositories;
public class PlatformRepository : IPlatformRepository {
    private readonly IRepositoryHelper<Platform> _repositoryHelper;
    private readonly BaseContext _db;
    public PlatformRepository(BaseContext db, IRepositoryHelper<Platform> repositoryHelper) {
        this._db = db;
        this._repositoryHelper = repositoryHelper;
    }

    public async Task<IEnumerable<Platform>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IQueryable<Platform> platformsQuery = _db.Platforms;

        platformsQuery = _repositoryHelper.ApplyFilters(platformsQuery, filters);
        platformsQuery = _repositoryHelper.ApplyOrder(platformsQuery, order);
        platformsQuery = _repositoryHelper.ApplyPagination(platformsQuery, pagination);

        return await platformsQuery.ToListAsync();
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