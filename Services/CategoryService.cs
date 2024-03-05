using AutoMapper;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services;

public class CategoryService : ICrudService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto> {

    private readonly BaseContext _db;

    private readonly IMapper _mapper;

    public CategoryService(BaseContext db, IMapper mapper) {
       this._db = db;
       this._mapper = mapper;
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

    public async Task<Category> Create(CreateCategoryDto createCategoryDto) {
        Category category = this._mapper.Map<Category>(createCategoryDto);

        this._db.Categories.Add(category);

        await _db.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> Update(int id, UpdateCategoryDto updateCategoryDto) {

        Category? category = await this.Find(id);

        if(category is null)
            return null;

        this._mapper.Map(updateCategoryDto, category);

        await this._db.SaveChangesAsync();

        return category;
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