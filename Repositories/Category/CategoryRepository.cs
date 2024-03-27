using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Repositories;
public class CategoryRepository : ICategoryRepository {
    private readonly IRepositoryHelper<Category> _repositoryHelper;
    private readonly BaseContext _db;
    public CategoryRepository(BaseContext db, IRepositoryHelper<Category> helper) {
        this._db = db;
        this._repositoryHelper = helper;
    }

    public async Task<IEnumerable<Category>> Get(RequestFilter[]? filters) {
        IQueryable<Category> categoriesQuery = _db.Categories;

        categoriesQuery = _repositoryHelper.ApplyFilters(categoriesQuery, filters);

        return await categoriesQuery.ToListAsync();
    }

    public async Task<Category?> Find(int id) {
        Category? category = await _db.Categories
            .Include(category => category.Games)
        .FirstOrDefaultAsync(category => category.Id == id);

        return category;
    }

    public async Task<Category?> FindByName(string name) {
        Category? category = await _db.Categories.FirstOrDefaultAsync(p => p.Name == name);

        return category;
    }

    public async Task<IEnumerable<Category>> FindByIds(List<int> ids) {
        return await _db.Categories.Where(category => ids.Contains(category.Id)).ToListAsync();
    }
    public async Task Create(Category category) {
        await _db.Categories.AddAsync(category);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Category category) {
        _db.Entry(category).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Category category) {
        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
    }

}