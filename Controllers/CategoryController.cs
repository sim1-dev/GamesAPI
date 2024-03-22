using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Dtos;
using GamesAPI.Models;
using AutoMapper;
using GamesAPI.Services;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper) {
        this._categoryService = categoryService;
        this._mapper = mapper;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get() {
        List<Category> categories = (await this._categoryService.GetAll()).ToList();

        List<CategoryDto> categoryDtos = this._mapper.Map<List<CategoryDto>>(categories);

        return Ok(categoryDtos);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDetailDto>> Find(int id) {
        Category? category = await this._categoryService.Find(id);

        if(category is null)
            return NotFound();

        CategoryDetailDto categoryDetailDto = this._mapper.Map<CategoryDetailDto>(category);

        return Ok(categoryDetailDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createCategoryDto) {
        if(createCategoryDto is null)
            return BadRequest();

        Category? existingCategory = await this._categoryService.FindByName(createCategoryDto.Name);

        if(existingCategory is not null)
            return Conflict("Category already exists");



        Category? category = await this._categoryService.Create(createCategoryDto);

        if(category is null)
            return StatusCode(500, "An error has occurred while creating. Please contact the system administrator");  

        CategoryDto categoryDto = this._mapper.Map<CategoryDto>(category);

        return categoryDto;
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] UpdateCategoryDto updateCategoryDto) {
        if(updateCategoryDto is null)
            return BadRequest();

        Category? category = await this._categoryService.Update(id, updateCategoryDto);

        if(category is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");

        CategoryDto categoryDto = this._mapper.Map<CategoryDto>(category);

        return categoryDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryDto>> Delete(int id) {
        bool isDeleted = await this._categoryService.Delete(id);

        if(!isDeleted)
            return NotFound();

        return Ok();
    }
}
