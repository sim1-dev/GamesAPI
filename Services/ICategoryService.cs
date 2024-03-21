using GamesAPI.Core.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

public interface ICategoryService : IService<Category, CreateCategoryDto, UpdateCategoryDto> {
    public Task<Category?> FindByName(string name);
}