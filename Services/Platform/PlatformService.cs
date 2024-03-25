using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Repositories;
using GamesAPI.Dtos;

namespace GamesAPI.Services;

public class PlatformService : IPlatformService {
    private readonly IPlatformRepository _platformRepository;

    private readonly IMapper _mapper;

    public PlatformService(IPlatformRepository platformRepository, IMapper mapper) {
        this._platformRepository = platformRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<Platform>> GetAll() {
        IEnumerable<Platform> platforms = await this._platformRepository.GetAll();
        return platforms;
    }
    
    public async Task<Platform?> Find(int id) {
        Platform? platform = await this._platformRepository.Find(id);

        return platform;
    }

    public async Task<Platform?> FindByName(string name) {
        Platform? platform = await this._platformRepository.FindByName(name);

        return platform;
    }

    public async Task<IEnumerable<Platform>> FindByIds(List<int> ids) {
        IEnumerable<Platform> platforms = await this._platformRepository.FindByIds(ids);
        
        return platforms;
    }

    public async Task<Platform> Create(CreatePlatformDto createPlatformDto) {
        Platform platform = this._mapper.Map<Platform>(createPlatformDto);

        await this._platformRepository.Create(platform);

        return platform;
    }

    public async Task<Platform?> Update(int id, UpdatePlatformDto updatePlatformDto) {
        Platform? platform = await this._platformRepository.Find(id);

        if(platform is null)
            return null;

        Platform updatedPlatform = _mapper.Map(updatePlatformDto, platform);

        await this._platformRepository.Update(updatedPlatform);

        return platform;
    }

    public async Task<bool> Delete(int id) {
        Platform? platform = await this._platformRepository.Find(id);

        if(platform is null)
            return false;

        await this._platformRepository.Delete(platform);

        return true;
    }
}