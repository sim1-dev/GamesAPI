using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Repositories;
using GamesAPI.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Services;

public class DeveloperService : IDeveloperService {
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;

    public DeveloperService(IDeveloperRepository developerRepository, IMapper mapper) {
        this._developerRepository = developerRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<Developer>> Get(RequestFilter[]? filters, RequestOrder? order) {
        IEnumerable<Developer> developers = await this._developerRepository.Get(filters, order);
        return developers;
    }

    public async Task<IEnumerable<Developer>> GetByUserId(int userId) {
        IEnumerable<Developer> developers = await this._developerRepository.GetByUserId(userId);
        return developers;
    }
    
    public async Task<Developer?> Find(int id) {
        Developer? developer = await this._developerRepository.Find(id);

        if(developer is null)
            return null;

        return developer;
    }

    public async Task<Developer> Create(CreateDeveloperDto createDeveloperDto) {
        Developer developer = this._mapper.Map<Developer>(createDeveloperDto);

        await this._developerRepository.Create(developer);

        return developer;
    }

    public async Task<Developer>CreateForUser(int userId, CreateDeveloperForUserDto createDeveloperForUserDto) {
        CreateDeveloperDto createDeveloperDto = this._mapper.Map<CreateDeveloperDto>(createDeveloperForUserDto);

        createDeveloperDto.UserId = userId;
        return await this.Create(createDeveloperDto);
    }

    public async Task<Developer?> Update(int id, UpdateDeveloperDto updateDeveloperDto) {
        Developer? developer = await this._developerRepository.Find(id);

        if(developer is null)
            return null;

        Developer updatedDeveloper = _mapper.Map(updateDeveloperDto, developer);

        await this._developerRepository.Update(updatedDeveloper);

        return developer;
    }

    public async Task<bool> Delete(int id) {
        Developer? developer = await this._developerRepository.Find(id);

        if(developer is null)
            return false;

        await this._developerRepository.Delete(developer);

        return true;
    }
}