using GamesAPI.Core.Services;
using GamesAPI.Dtos;
using GamesAPI.Models;

namespace GamesAPI.Services;

public interface IDeveloperService : IService<Developer, CreateDeveloperDto, UpdateDeveloperDto> {
    public Task<IEnumerable<Developer>> GetByUserId(int userId);
    public Task<Developer>CreateForUser(int userId, CreateDeveloperForUserDto createDeveloperForUserDto);
}