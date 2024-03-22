using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

namespace GamesAPI.Services;

public interface ISoftwareHouseService : IService<SoftwareHouse, CreateSoftwareHouseDto, UpdateSoftwareHouseDto> {
    public Task<SoftwareHouse?> FindByName(string name);
}