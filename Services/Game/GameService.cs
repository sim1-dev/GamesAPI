using AutoMapper;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Services;
using GamesAPI.Models;
using GamesAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services;

public class GameService : ICrudService<Game, GameDto, CreateGameDto, UpdateGameDto> {

    private readonly BaseContext _db;
    private readonly PlatformService _platformService;
    private readonly IMapper _mapper;

    public GameService(BaseContext db, PlatformService platformService, IMapper mapper) {
       this._db = db;
       this._platformService = platformService;
       this._mapper = mapper;
    }

    public async Task<List<Game>> GetAll() {
        List<Game> games = await this._db.Games
            .Include(game => game.Platforms)
            .Include(game => game.SoftwareHouse)
            .Include(game => game.Category)
            .Include(game => game.Reviews)  // TODO [perf] (non voglio caricare tutte le reviews per un'aggregazione)
        .ToListAsync();

        return games;
    }

    public async Task<Game?> Find(int id) {
        Game? game = await this._db.Games
            .Include(game => game.Platforms)
            .Include(game => game.SoftwareHouse)
            .Include(game => game.Category)
            .Include(game => game.Reviews!)
                .ThenInclude(review => review.ReviewerUser)
        .FirstOrDefaultAsync(game => game.Id == id);
        
        return game;
    }

    public async Task<Game> Create(CreateGameDto createGameDto) {

        Game game = this._mapper.Map<Game>(createGameDto);

        // https://learn.microsoft.com/it-it/dotnet/fundamentals/code-analysis/quality-rules/ca1860
        if(createGameDto.PlatformIds!.Count != 0)
            game.Platforms = await this._platformService.FindByIds(createGameDto.PlatformIds!);

        this._db.Games.Add(game);

        await this._db.SaveChangesAsync();

        return game;
    }

    public async Task<Game?> Update(int id, UpdateGameDto updateGameDto) {

        Game? game = await this.Find(id);

        if(game is null)
            return null;

        this._db.Entry(game).CurrentValues.SetValues(updateGameDto);

        await this._db.SaveChangesAsync();

        return game;
    }

    public async Task<Game?> Delete(int id) {
        Game? game = await this.Find(id);

        if(game is null)
            return null;

        this._db.Games.Remove(game);

        await this._db.SaveChangesAsync();

        return game;
    }
}