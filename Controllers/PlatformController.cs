using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace PlatformsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly PlatformService _platformService;

    public PlatformController(IMapper mapper, PlatformService platformService) {
        this._mapper = mapper;
        this._platformService = platformService;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<Collection<PlatformDto>>> Get() {
        List<Platform>? platforms = await this._platformService.GetAll();

        if(platforms is null)
            return NotFound();

        List<PlatformDto> platformDtos = _mapper.Map<List<PlatformDto>>(platforms);

        return Ok(platformDtos);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<PlatformDetailDto>> Find(int id) {
        Platform? platform = await this._platformService.Find(id);

        if(platform is null)
            return NotFound();

        PlatformDetailDto platformDetailDto = _mapper.Map<PlatformDetailDto>(platform);

        return Ok(platformDetailDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<PlatformDto>> Create(CreatePlatformDto createPlatformDto) {
        if(createPlatformDto is null)
            return BadRequest();
            
        Platform platform = _mapper.Map<Platform>(createPlatformDto);


        Platform? existingPlatform = await this._platformService.FindByName(platform.Name);

        if(existingPlatform is not null)
            return StatusCode(409, "Platform already exists");


        Platform? createdPlatform = await this._platformService.Create(platform);

        if(createdPlatform is null)
            return StatusCode(500, "An error has occurred while creating. Please contact the system administrator");  

            
        PlatformDto createdPlatformDto = _mapper.Map<PlatformDto>(createdPlatform);

        return createdPlatformDto;
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<PlatformDto>> Update(int id, [FromBody] UpdatePlatformDto updatePlatformDto) {
        if(updatePlatformDto is null)
            return BadRequest();

        Platform platform = _mapper.Map<Platform>(updatePlatformDto);

        Platform? updatedPlatform = await this._platformService.Update(id, platform);

        if(updatedPlatform is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        PlatformDto updatedPlatformDto = _mapper.Map<PlatformDto>(updatedPlatform);

        return updatedPlatformDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<PlatformDto>> Delete(int id) {
            
        Platform? platform = await this._platformService.Delete(id);

        if(platform is null)
            return NotFound();

        return Ok();
    }
}
