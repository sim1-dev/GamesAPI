using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;
using GamesAPI.Services;
using GamesAPI.Core.Services;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SoftwareHouseController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly SoftwareHouseService _softwareHouseService;

    public SoftwareHouseController(IMapper mapper, SoftwareHouseService softwareHouseService) {
        this._mapper = mapper;
        this._softwareHouseService = softwareHouseService;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<Collection<SoftwareHouseDto>>> Get() {
        List<SoftwareHouse>? softwareHouses = await this._softwareHouseService.GetAll();

        if(softwareHouses is null)
            return NotFound();

        List<SoftwareHouseDto> softwareHouseDtos = _mapper.Map<List<SoftwareHouseDto>>(softwareHouses);

        return Ok(softwareHouseDtos);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<SoftwareHouseDetailDto>> Find(int id) {
        SoftwareHouse? softwareHouse = await this._softwareHouseService.Find(id);

        if(softwareHouse is null)
            return NotFound();

        SoftwareHouseDetailDto softwareHouseDto = _mapper.Map<SoftwareHouseDetailDto>(softwareHouse);

        return Ok(softwareHouseDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<SoftwareHouseDto>> Create(CreateSoftwareHouseDto createSoftwareHouseDto) {
        if(createSoftwareHouseDto is null)
            return BadRequest();

        SoftwareHouse softwareHouse = await this._softwareHouseService.Create(createSoftwareHouseDto);
            
        SoftwareHouseDto softwareHouseDto = _mapper.Map<SoftwareHouseDto>(softwareHouse);

        return softwareHouseDto;
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<SoftwareHouseDto>> Update(int id, [FromBody] UpdateSoftwareHouseDto updateSoftwareHouseDto) {
        if(updateSoftwareHouseDto is null)
            return BadRequest();

        SoftwareHouse? updatedSoftwareHouse = await this._softwareHouseService.Update(id, updateSoftwareHouseDto);

        if(updatedSoftwareHouse is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        SoftwareHouseDto updatedSoftwareHouseDto = _mapper.Map<SoftwareHouseDto>(updatedSoftwareHouse);

        return updatedSoftwareHouseDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<SoftwareHouseDto>> Delete(int id) {
            
        SoftwareHouse? softwareHouse = await this._softwareHouseService.Delete(id);

        if(softwareHouse is null)
            return NotFound();

        return Ok();
    }
}
