using AutoMapper;
using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services;

public class PlatformService : ICrudService<Platform, PlatformDto, CreatePlatformDto, UpdatePlatformDto> {

    private readonly BaseContext _db;
    private readonly IMapper _mapper;

    public PlatformService(BaseContext db, IMapper mapper) {
       this._db = db;
       this._mapper = mapper;
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

    public async Task<Platform> Create(CreatePlatformDto createPlatformDto) {
        Platform platform = this._mapper.Map<Platform>(createPlatformDto);

        this._db.Platforms.Add(platform);

        await _db.SaveChangesAsync();

        return platform;
    }

    public async Task<Platform?> Update(int id, UpdatePlatformDto updatePlatformDto) {

        Platform? platform = await this.Find(id);

        if(platform is null)
            return null;

        this._db.Entry(platform).CurrentValues.SetValues(updatePlatformDto);

        await this._db.SaveChangesAsync();

        return platform;
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