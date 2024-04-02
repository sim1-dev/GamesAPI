using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Repositories;
using GamesAPI.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Services;

public class CategoryService : ICategoryService {
    private readonly ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
        this._categoryRepository = categoryRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<Category>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IEnumerable<Category> categories = await this._categoryRepository.Get(filters, order, pagination);
        return categories;
    }
    
    public async Task<Category?> Find(int id) {
        Category? category = await this._categoryRepository.Find(id);

        if(category is null)
            return null;

        return category;
    }

    public async Task<Category?> FindByName(string name) {
        Category? category = await this._categoryRepository.FindByName(name);

        if(category is null)
            return null;

        return category;
    }

    public async Task<Category> Create(CreateCategoryDto createCategoryDto) {
        Category category = this._mapper.Map<Category>(createCategoryDto);

        await this._categoryRepository.Create(category);

        return category;
    }

    public async Task<Category?> Update(int id, UpdateCategoryDto updateCategoryDto) {
        Category? category = await this._categoryRepository.Find(id);

        if(category is null)
            return null;

        Category updatedCategory = _mapper.Map(updateCategoryDto, category);

        await this._categoryRepository.Update(updatedCategory);

        return category;
    }

    public async Task<bool> Delete(int id) {
        Category? category = await this._categoryRepository.Find(id);

        if(category is null)
            return false;

        await this._categoryRepository.Delete(category);

        return true;
    }
}