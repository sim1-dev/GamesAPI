using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;
using GamesAPI.Services;

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

        Platform? existingPlatform = await this._platformService.FindByName(createPlatformDto.Name);

        if(existingPlatform is not null)
            return StatusCode(409, "Platform already exists");


        Platform? platform = await this._platformService.Create(createPlatformDto);

        if(platform is null)
            return StatusCode(500, "An error has occurred while creating. Please contact the system administrator");  

            
        PlatformDto platformDto = _mapper.Map<PlatformDto>(platform);

        return platformDto;
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<PlatformDto>> Update(int id, [FromBody] UpdatePlatformDto updatePlatformDto) {
        if(updatePlatformDto is null)
            return BadRequest();

        Platform? platform = await this._platformService.Update(id, updatePlatformDto);

        if(platform is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        PlatformDto platformDto = _mapper.Map<PlatformDto>(platform);

        return platformDto;
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
