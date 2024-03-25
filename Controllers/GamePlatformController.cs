// TODO [refactor]

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Services;
using GamesAPI.Models;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class GamePlatformController : ControllerBase
{
    private readonly IGamePlatformService _gamePlatformService;

    public GamePlatformController(IGamePlatformService gamePlatformService) {
        this._gamePlatformService = gamePlatformService;
    }

    // [Authorize(Policy = "IsGameDeveloper")]
    [HttpPost]
    public async Task<ActionResult<GamePlatform>> Create(int gameId, int platformId) {
        GamePlatform gamePlatform = await this._gamePlatformService.Create(gameId, platformId);

        if(gamePlatform is null)
            return StatusCode(500, "An error has occurred while creating. Please contact the system administrator");

        return Ok(gamePlatform);
    }

    [Authorize(Policy = "IsGameDeveloper")]
    [Route("game/{gameId}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteAllPlatformsForGame(int gameId) {
        bool isDeleted = await this._gamePlatformService.DeleteForGame(gameId);

        if(!isDeleted)
            return NotFound();

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [Route("platform/{platformId}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteAllGamesForPlatform(int platformId) {
        bool isDeleted = await this._gamePlatformService.DeleteForPlatform(platformId);

        if(!isDeleted)
            return NotFound();

        return Ok();
    }
}