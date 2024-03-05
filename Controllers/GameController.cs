using Microsoft.AspNetCore.Mvc;
using GamesAPI.Core.Models;
using System.Collections.ObjectModel;
using AutoMapper;
using GamesAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Services;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly GameService _gameService;
    private readonly PlatformService _platformService;

    public GameController(IMapper mapper, GameService gameService, PlatformService platformService) {
        this._mapper = mapper;
        this._gameService = gameService;
        this._platformService = platformService;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<Collection<GameDto>>> Get() {
        List<Game>? games = await this._gameService.GetAll();

        if(games is null)
            return NotFound();

        List<GameDto> gameDtos = _mapper.Map<List<GameDto>>(games);

        return Ok(gameDtos);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<GameDetailDto>> Find(int id) {
        Game? game = await this._gameService.Find(id);

        if(game is null)
            return NotFound();

        GameDetailDto gameDetailDto = _mapper.Map<GameDetailDto>(game);

        return Ok(gameDetailDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<GameDto>> Create(CreateGameDto createGameDto) {
        if(createGameDto is null)
            return BadRequest();

        Game game = await this._gameService.Create(createGameDto);  
            
        GameDto gameDto = _mapper.Map<GameDto>(game);

        return gameDto;
    }

    [Authorize(Policy = "IsGameDeveloper")]
    [HttpPut("{id}")]
    public async Task<ActionResult<GameDto>> Update(int id, [FromBody] UpdateGameDto updateGameDto) {
        if(updateGameDto is null)
            return BadRequest();

        Game? game = await this._gameService.Update(id, updateGameDto);

        if(game is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        GameDto gameDto = _mapper.Map<GameDto>(game);

        return gameDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "IsGameDeveloper")]
    public async Task<ActionResult<GameDto>> Delete(int id) {
            
        Game? game = await this._gameService.Delete(id);

        if(game is null)
            return NotFound();

        return Ok();
    }
}
