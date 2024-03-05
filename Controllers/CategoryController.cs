using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;
using GamesAPI.Services;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly CategoryService _categoryService;

    public CategoryController(IMapper mapper, CategoryService categoryService) {
        this._mapper = mapper;
        this._categoryService = categoryService;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<Collection<CategoryDto>>> Get() {
        List<Category>? categories = await this._categoryService.GetAll();

        if(categories is null)
            return NotFound();

        List<CategoryDto> categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

        return Ok(categoryDtos);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDetailDto>> Find(int id) {
        Category? category = await this._categoryService.Find(id);

        if(category is null)
            return NotFound();

        CategoryDetailDto categoryDetailDto = _mapper.Map<CategoryDetailDto>(category);

        return Ok(categoryDetailDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createCategoryDto) {
        if(createCategoryDto is null)
            return BadRequest();
            
        Category category = _mapper.Map<Category>(createCategoryDto);


        Category? existingCategory = await this._categoryService.FindByName(category.Name);

        if(existingCategory is not null)
            return StatusCode(409, "Category already exists");


        Category? createdCategory = await this._categoryService.Create(category);

        if(createdCategory is null)
            return StatusCode(500, "An error has occurred while creating. Please contact the system administrator");  

            
        CategoryDto createdCategoryDto = _mapper.Map<CategoryDto>(createdCategory);

        return createdCategoryDto;
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] UpdateCategoryDto updateCategoryDto) {
        if(updateCategoryDto is null)
            return BadRequest();

        Category category = _mapper.Map<Category>(updateCategoryDto);

        Category? updatedCategory = await this._categoryService.Update(id, category);

        if(updatedCategory is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        CategoryDto updatedCategoryDto = _mapper.Map<CategoryDto>(updatedCategory);

        return updatedCategoryDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryDto>> Delete(int id) {
            
        Category? category = await this._categoryService.Delete(id);

        if(category is null)
            return NotFound();

        return Ok();
    }
}
