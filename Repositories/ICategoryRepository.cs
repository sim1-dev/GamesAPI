using GamesAPI.Core.Models;

namespace GamesAPI.Core.Repositories;

public interface ICategoryRepository : IRepository<Category> {
    public Task<Category?> FindByName(string name);
}