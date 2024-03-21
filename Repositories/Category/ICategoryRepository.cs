using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface ICategoryRepository : IRepository<Category> {
    public Task<Category?> FindByName(string name);
}