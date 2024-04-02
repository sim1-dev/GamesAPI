using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Core.Repositories;

public class UserRepository : IUserRepository {
    private readonly IRepositoryHelper<User> _repositoryHelper;
    private readonly UserManager<User> _userManager;
    private readonly BaseContext _db;
    public UserRepository(UserManager<User> userManager, BaseContext db, IRepositoryHelper<User> repositoryHelper) {
        this._userManager = userManager;
        this._db = db;
        this._repositoryHelper = repositoryHelper;
    }

    public async Task<IEnumerable<User>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IQueryable<User> usersQuery = _db.Users;

        usersQuery = _repositoryHelper.ApplyFilters(usersQuery, filters);
        usersQuery = _repositoryHelper.ApplyOrder(usersQuery, order);
        usersQuery = _repositoryHelper.ApplyPagination(usersQuery, pagination);

        return await usersQuery.ToListAsync();
    }

    public async Task<User?> Find(int id) {
        User? user = await _db.Users
            .Include(user => user.DeveloperAccounts)
        .FirstOrDefaultAsync(user => user.Id == id);

        return user;
    }

    public async Task Create(User user) {
        IdentityResult result = await _userManager.CreateAsync(user, "Password1!");

        if(!result.Succeeded)
            throw new Exception("Failed to create user");

        await _userManager.AddToRoleAsync(user, "User");

        await _db.SaveChangesAsync();
    }

    public async Task CreateWithPassword(User user, string password = "Password1!") {
        IdentityResult result = await _userManager.CreateAsync(user, password);

        if(!result.Succeeded)
            throw new Exception("Failed to create user");

        await _userManager.AddToRoleAsync(user, "User");

        await _db.SaveChangesAsync();
    }

    public async Task Update(User user) {
        _db.Entry(user).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task UpdateWithPassword(User user, string newPassword = "Password1!") {
        await _userManager.RemovePasswordAsync(user);

        IdentityResult result = await _userManager.AddPasswordAsync(user, newPassword);

        if(!result.Succeeded)
            throw new Exception("Failed to update user");

        _db.Entry(user).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(User user) {
        await _userManager.DeleteAsync(user);
        await _db.SaveChangesAsync();
    }

}