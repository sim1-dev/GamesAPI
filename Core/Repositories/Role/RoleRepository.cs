using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Core.Repositories;

public class RoleRepository : IRoleRepository {
    private readonly IRepositoryHelper<Role> _repositoryHelper;
    private readonly RoleManager<Role> _roleManager;
    private readonly BaseContext _db;
    public RoleRepository(RoleManager<Role> roleManager, BaseContext db, IRepositoryHelper<Role> repositoryHelper) {
        this._roleManager = roleManager;
        this._db = db;
        this._repositoryHelper = repositoryHelper;
    }

    public async Task<IEnumerable<Role>> Get(RequestFilter[]? filters) {
        IQueryable<Role> rolesQuery = _db.Roles;

        rolesQuery = _repositoryHelper.ApplyFilters(rolesQuery, filters);

        return await rolesQuery.ToListAsync();
    }

    public async Task<Role?> Find(int id) {
        Role? role = await _db.Roles
            .Include(role => role.Users)
        .FirstOrDefaultAsync(role => role.Id == id);

        return role;
    }



    public async Task Create(Role role) {
        IdentityResult result = await _roleManager.CreateAsync(role);

        if(!result.Succeeded)
            throw new Exception("Failed to create role");

        await _db.SaveChangesAsync();
    }

    public async Task Update(Role role) {
        IdentityResult result = await _roleManager.UpdateAsync(role);

        if(!result.Succeeded)
            throw new Exception("Failed to update role");

        await _db.SaveChangesAsync();
    }

    public async Task Delete(Role role) {
        await _roleManager.DeleteAsync(role);
        await _db.SaveChangesAsync();
    }

}