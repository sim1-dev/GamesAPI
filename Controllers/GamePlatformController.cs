// TODO [refactor]

// using Microsoft.AspNetCore.Mvc;
// using GamesAPI.Models;
// using AutoMapper;
// using GamesAPI.Dtos;
// using Microsoft.AspNetCore.Authorization;
// using GamesAPI.Services;

// namespace GamesAPI.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class GamePlatformController : ControllerBase
// {
//     private readonly IMapper _mapper;

//     private readonly IGamePlatformService _gamePlatformService;

//     public GamePlatformController(IMapper mapper, GamePlatformService gamePlatformService) {
//         this._mapper = mapper;
//         this._gamePlatformService = gamePlatformService;
//     }

    
//     // [Authorize(Policy = "IsGameDeveloper")]
//     // [HttpPut("/add")]
//     // public async Task<ActionResult<GameDto>> AddPlatform([FromBody]int gameId, int platformId) {
//     //     Game? game = await this._gameService.Find(gameId);

//     //     if(game is null)
//     //         return NotFound("Game not found");

//     //     Platform? platform = await this._platformService.Find(platformId);

//     //     if(platform is null)
//     //         return NotFound("Platform not found");

//     //     Game? updatedGame = await this._gamePlatformService.AddPlatformToGame(game, platform);

//     //     if(updatedGame is null)
//     //         return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");

//     //     GameDto updatedGameDto = _mapper.Map<GameDto>(updatedGame);

//     //     return updatedGameDto;
//     // }

//     // [Authorize(Policy = "IsGameDeveloper")]
//     // [HttpPut("{gameId}/remove")]
//     // public async Task<ActionResult<GameDto>> RemovePlatform(int gameId, [FromBody] int platformId) {
//     //     Game? game = await this._gameService.Find(gameId);

//     //     if(game is null)
//     //         return NotFound("Game not found");

//     //     Platform? platform = await this._platformService.Find(platformId);

//     //     if(platform is null)
//     //         return NotFound("Platform not found");

//     //     Game? updatedGame = await this._gamePlatformService.RemovePlatformToGame(game, platform);

//     //     if(updatedGame is null)
//     //         return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");

//     //     GameDto updatedGameDto = _mapper.Map<GameDto>(updatedGame);

//     //     return updatedGameDto;
//     // }
// }