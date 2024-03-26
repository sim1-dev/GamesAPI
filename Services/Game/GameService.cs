using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;
using GamesAPI.Repositories;
using GamesAPI.Core.Services;

namespace GamesAPI.Services;

public class GameService : IGameService {

    private readonly IFileService _fileService;
    private readonly IPlatformService _platformService;
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper, IPlatformService platformService, IFileService fileService) {
        this._platformService = platformService;
        this._gameRepository = gameRepository;
        this._mapper = mapper;
        this._fileService = fileService;
    }

    public async Task<IEnumerable<Game>> GetAll() {
        IEnumerable<Game> games = await this._gameRepository.GetAll();

        return games;
    }

    public async Task<Game?> Find(int id) {
        Game? game = await this._gameRepository.Find(id);
        
        return game;
    }

    public async Task<Game> Create(CreateGameDto createGameDto) {
        Game game = this._mapper.Map<Game>(createGameDto);

        // https://learn.microsoft.com/it-it/dotnet/fundamentals/code-analysis/quality-rules/ca1860
        if(createGameDto.PlatformIds!.Count != 0)
            game.Platforms = (await this._platformService.FindByIds(createGameDto.PlatformIds!)).ToList();

        await this._gameRepository.Create(game);

        return game;
    }

    public async Task<Game?> Update(int id, UpdateGameDto updateGameDto) {
        Game? game = await this._gameRepository.Find(id);

        if(game is null)
            return null;

        Game updatedGame = _mapper.Map(updateGameDto, game);

        if(updateGameDto.PlatformIds!.Count != 0)
            game.Platforms = (await this._platformService.FindByIds(updateGameDto.PlatformIds!)).ToList();

        await this._gameRepository.Update(updatedGame);

        return game;
    }

    public async Task<Game?> UpdateImage(Game game, IFormFile file) {
        string filePath = await this._fileService.Upload(file);

        game.ImageUrl = filePath;

        UpdateGameDto updateGameDto = _mapper.Map<UpdateGameDto>(game);

        return await this.Update(game.Id, updateGameDto);
    }

    public async Task<bool> Delete(int id) {
        Game? game = await this._gameRepository.Find(id);

        if(game is null)
            return false;

        await this._gameRepository.Delete(game);

        return true;
    }
}