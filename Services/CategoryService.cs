using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services;

public class CategoryService {

    private readonly BaseContext _db;

    public CategoryService(BaseContext db) {
       this._db = db;
    }

    public async Task<List<Category>> GetAll() {
        return await _db.Categories.ToListAsync();
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

    public async Task<List<Category>> FindByIds(List<int> ids) {
        return await _db.Categories.Where(category => ids.Contains(category.Id)).ToListAsync();
    }

    public async Task<Category> Create(Category category) {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> Update(int id, Category category) {

        Category? existingCategory = await this.Find(id);

        if(existingCategory is null)
            return null;

        this._db.Entry(existingCategory).CurrentValues.SetValues(category);

        await this._db.SaveChangesAsync();

        return existingCategory;
    }

    public async Task<Category?> Delete(int id) {
        Category? category = await this.Find(id);

        if(category is null)
            return null;

        this._db.Categories.Remove(category);

        await this._db.SaveChangesAsync();

        return category;
    }

}