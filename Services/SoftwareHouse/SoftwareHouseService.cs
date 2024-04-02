using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Repositories;
using GamesAPI.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Services;

public class SoftwareHouseService : ISoftwareHouseService {
    private readonly ISoftwareHouseRepository _softwareHouseRepository;

    private readonly IMapper _mapper;

    public SoftwareHouseService(ISoftwareHouseRepository softwareHouseRepository, IMapper mapper) {
        this._softwareHouseRepository = softwareHouseRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<SoftwareHouse>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IEnumerable<SoftwareHouse> softwareHouses = await this._softwareHouseRepository.Get(filters, order, pagination);

        return softwareHouses;
    }
    
    public async Task<SoftwareHouse?> Find(int id) {
        SoftwareHouse? softwareHouse = await this._softwareHouseRepository.Find(id);

        return softwareHouse;
    }

    public async Task<SoftwareHouse?> FindByName(string name) {
        SoftwareHouse? softwareHouse = await this._softwareHouseRepository.FindByName(name);

        return softwareHouse;
    }

    public async Task<SoftwareHouse> Create(CreateSoftwareHouseDto createSoftwareHouseDto) {
        SoftwareHouse softwareHouse = this._mapper.Map<SoftwareHouse>(createSoftwareHouseDto);

        await this._softwareHouseRepository.Create(softwareHouse);

        return softwareHouse;
    }

    public async Task<SoftwareHouse?> Update(int id, UpdateSoftwareHouseDto updateSoftwareHouseDto) {
        SoftwareHouse? softwareHouse = await this._softwareHouseRepository.Find(id);

        if(softwareHouse is null)
            return null;

        SoftwareHouse updatedSoftwareHouse = _mapper.Map(updateSoftwareHouseDto, softwareHouse);

        await this._softwareHouseRepository.Update(updatedSoftwareHouse);

        return softwareHouse;
    }

    public async Task<bool> Delete(int id) {
        SoftwareHouse? softwareHouse = await this._softwareHouseRepository.Find(id);

        if(softwareHouse is null)
            return false;

        await this._softwareHouseRepository.Delete(softwareHouse);

        return true;
    }
}