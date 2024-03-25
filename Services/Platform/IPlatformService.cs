using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

namespace GamesAPI.Services;

public interface IPlatformService : IService<Platform, CreatePlatformDto, UpdatePlatformDto> {
    public Task<Platform?> FindByName(string name);
    public Task<IEnumerable<Platform>> FindByIds(List<int> ids);
}