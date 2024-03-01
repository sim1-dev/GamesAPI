using Microsoft.AspNetCore.Mvc;
using GamesAPI.Core.Models;
using System.Collections.ObjectModel;
using AutoMapper;
using GamesAPI.Dtos;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly GameService _gameService;

    public GameController(IMapper mapper, GameService gameService) {
        this._mapper = mapper;
        this._gameService = gameService;
    }

	[HttpGet]
    public async Task<ActionResult<Collection<GameDto>>> Get() {
        List<Game>? games = await this._gameService.GetAll();

        if(games is null)
            return NotFound();

        List<GameDto> gameDtos = _mapper.Map<List<GameDto>>(games);

        return Ok(gameDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDetailDto>> Find(int id) {
        Game? game = await this._gameService.Find(id);

        if(game is null)
            return NotFound();

        GameDetailDto gameDetailDto = _mapper.Map<GameDetailDto>(game);

        return Ok(gameDetailDto);
    }

    [HttpPost]
    public async Task<ActionResult<GameDto>> Create(CreateGameDto createGameDto) {
        if(createGameDto is null)
            return BadRequest();

        Game game = _mapper.Map<Game>(createGameDto);

        Game? createdGame = await this._gameService.Create(game);

        if(createdGame is null)
            return StatusCode(500, "An error has occurred while creating. Please contact the system administrator");     
            
        GameDto createdGameDto = _mapper.Map<GameDto>(createdGame);

        return createdGameDto;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameDto>> Update(int id, [FromBody] UpdateGameDto updateGameDto) {
        if(updateGameDto is null)
            return BadRequest();

        Game game = _mapper.Map<Game>(updateGameDto);

        Game? updatedGame = await this._gameService.Update(id, game);

        if(updatedGame is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        GameDto updatedGameDto = _mapper.Map<GameDto>(updatedGame);

        return updatedGameDto;
    }

    [HttpDelete("{id}")]
    // TODO policy only if developer belongs to software
    public async Task<ActionResult<GameDto>> Delete(int id) {
            
        Game? game = await this._gameService.Delete(id);

        if(game is null)
            return NotFound();

        return Ok();
    }
}
