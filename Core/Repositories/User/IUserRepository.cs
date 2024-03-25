using GamesAPI.Core.Models;

namespace GamesAPI.Core.Repositories;

public interface IUserRepository : IRepository<User> {
    public Task CreateWithPassword(User user, string password = "Password1!");
    public Task UpdateWithPassword(User user, string newPassword = "Password1!");
}