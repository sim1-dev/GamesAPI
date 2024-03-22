using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface ISoftwareHouseRepository : IRepository<SoftwareHouse> {
    public Task<SoftwareHouse?> FindByName(string name);
}