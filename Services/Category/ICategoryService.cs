using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

namespace GamesAPI.Services;

public interface ICategoryService : IService<Category, CreateCategoryDto, UpdateCategoryDto> {
    public Task<Category?> FindByName(string name);
}