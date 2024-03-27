using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Dtos;
using GamesAPI.Services;
using GamesAPI.Core.Services;
using GamesAPI.Models;
using GamesAPI.Core.Models;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class DeveloperController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IDeveloperService _developerService;
    private readonly UserContextService _userContextService;

    public DeveloperController(IMapper mapper, IDeveloperService developerService, UserContextService userContextService) {
        this._mapper = mapper;
        this._developerService = developerService;
        this._userContextService = userContextService;
    }

    // Admin scoped actions
    
    [Authorize(Roles = "Admin")]
	[HttpGet]
    public async Task<ActionResult<Collection<DeveloperDto>>> Get([FromQuery] RequestFilter[]? filters = null) {
        List<Developer> developers = (await this._developerService.Get(filters)).ToList();

        List<DeveloperDto> developerDtos = _mapper.Map<List<DeveloperDto>>(developers);

        return Ok(developerDtos);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<ActionResult<DeveloperDetailDto>> Find(int id) {
        Developer? developer = await this._developerService.Find(id);

        if(developer is null)
            return NotFound();

        DeveloperDetailDto developerDetailDto = _mapper.Map<DeveloperDetailDto>(developer);

        return Ok(developerDetailDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<DeveloperDto>> Create(CreateDeveloperDto createDeveloperDto) {
        if(createDeveloperDto is null)
            return BadRequest();

        Developer developer = await this._developerService.Create(createDeveloperDto);
            
        DeveloperDto developerDto = _mapper.Map<DeveloperDto>(developer);

        return developerDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<DeveloperDto>> Update(int id, [FromBody] UpdateDeveloperDto updateDeveloperDto) {
        if(updateDeveloperDto is null)
            return BadRequest();

        Developer? updatedDeveloper = await this._developerService.Update(id, updateDeveloperDto);

        if(updatedDeveloper is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        DeveloperDto updatedDeveloperDto = _mapper.Map<DeveloperDto>(updatedDeveloper);

        return updatedDeveloperDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<DeveloperDto>> Delete(int id) {
            
        bool isDeleted = await this._developerService.Delete(id);

        if(!isDeleted)
            return NotFound();

        return Ok();
    }




    // Self | User scoped action

    [HttpGet]
    [Authorize]
    [Route("user")]
    public async Task<ActionResult<Collection<DeveloperDto>>> GetForUser() {
        int userId = this._userContextService.GetUserId();

        List<Developer> developers = (await this._developerService.GetByUserId(userId)).ToList();

        List<DeveloperDto> developerDtos = _mapper.Map<List<DeveloperDto>>(developers);

        return Ok(developerDtos);
    }

    [HttpPost]
    [Authorize]
    [Route("user")]
    public async Task<ActionResult<DeveloperDto>> CreateForUser(CreateDeveloperForUserDto createDeveloperForUserDto) {
        if(createDeveloperForUserDto is null)
            return BadRequest();

        int userId = this._userContextService.GetUserId();

        Developer developer = await this._developerService.CreateForUser(userId, createDeveloperForUserDto);
            
        DeveloperDto developerDto = _mapper.Map<DeveloperDto>(developer);

        return developerDto;
    }



}
