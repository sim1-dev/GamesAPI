using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using GamesAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Services;
using GamesAPI.Core.Services;
using GamesAPI.Models;
using GamesAPI.Core.Models;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class GameController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IGameService _gameService;
    private readonly IFileService _fileService;
    private readonly IExcelExportService<ExportGameDto> _excelExportService;

    public GameController(IGameService gameService, IMapper mapper, IFileService fileService, IExcelExportService<ExportGameDto> excelExportService) {
        this._gameService = gameService;
        this._mapper = mapper;
        this._fileService = fileService;
        this._excelExportService = excelExportService;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<Collection<GameDto>>> Get([FromQuery] RequestFilter[]? filters = null) {
        List<Game>? games = (await this._gameService.Get(filters)).ToList();

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
        bool isDeleted = await this._gameService.Delete(id);

        if(!isDeleted)
            return NotFound();

        return Ok();
    }

    [HttpPatch("{id}/cover-image")]
    public async Task<IActionResult> UploadCoverImage(IFormFile file, int id) {
        if (file == null || file.Length == 0)
            return BadRequest();

        Game? game = await this._gameService.Find(id);

        if(game is null)
            return NotFound();


        Game? updatedGame = await this._gameService.UpdateImage(game, file);

        if(updatedGame is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");

        GameDto gameDto = _mapper.Map<GameDto>(updatedGame);

        return Ok(gameDto);
    }

    [HttpGet("{id}/cover-image")]
    public async Task<IActionResult> DownloadCoverImage(int id) {
        Game? game = await this._gameService.Find(id);

        if(game is null || game.ImageUrl is null)
            return NotFound();

        FileContents fileContents = this._fileService.Download(game.ImageUrl);

        return File(fileContents.Bytes, fileContents.MimeType, fileContents.FileName);
    }

    [HttpPost("export/excel")]
    public async Task<IActionResult> ExportToExcel([FromBody] string fileName = "games.xlsx") {
        List<Game> games = (await this._gameService.Get(null)).ToList();

        if(games is null)
            return NotFound();

        List<ExportGameDto> exportGameDtos = _mapper.Map<List<ExportGameDto>>(games);

        FileContents fileContents = this._excelExportService.Export(exportGameDtos, fileName);

        return File(fileContents.Bytes, fileContents.MimeType, fileContents.FileName);
    }
}
