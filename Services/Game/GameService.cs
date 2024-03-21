using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;
using GamesAPI.Repositories;

namespace GamesAPI.Services;

public class GameService : IGameService {
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper) {
        this._gameRepository = gameRepository;
        this._mapper = mapper;
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

        // TODO reimplement
        // // https://learn.microsoft.com/it-it/dotnet/fundamentals/code-analysis/quality-rules/ca1860
        // if(createGameDto.PlatformIds!.Count != 0)
        //     game.Platforms = await this._platformService.FindByIds(createGameDto.PlatformIds!);

        await this._gameRepository.Create(game);

        return game;
    }

    public async Task<Game?> Update(int id, UpdateGameDto updateGameDto) {
        Game? game = await this._gameRepository.Find(id);

        if(game is null)
            return null;

        // TODO debug: sovrascrive i campi mancanti con NULL
        Game updatedGame = _mapper.Map(updateGameDto, game);

        await this._gameRepository.Update(updatedGame);

        return game;
    }
    public async Task<bool> Delete(int id) {
        Game? game = await this._gameRepository.Find(id);

        if(game is null)
            return false;

        await this._gameRepository.Delete(game);

        return true;
    }
}