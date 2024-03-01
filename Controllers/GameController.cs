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
    public async Task<ActionResult<GameDto>> Create(GameDto gameDto) {
        if(gameDto is null)
            return BadRequest();

        Game game = _mapper.Map<Game>(gameDto);

        Game createdGame = await this._gameService.Create(game);

        GameDto createdGameDto = _mapper.Map<GameDto>(createdGame);

        return createdGameDto;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameDto>> Update(int id, [FromBody] GameDto gameDto) {
        if(gameDto is null)
            return BadRequest();

        Game game = _mapper.Map<Game>(gameDto);

        Game? updatedGame = await this._gameService.Update(id, game);

        if(updatedGame is null)
            return NotFound();        

        GameDto updatedGameDto = _mapper.Map<GameDto>(updatedGame);

        return updatedGameDto;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GameDto>> Delete(int id) {
            
        Game? game = await this._gameService.Delete(id);

        if(game is null)
            return NotFound();

        return Ok();
    }
}
