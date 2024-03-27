using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;
using StandardizedFilters.Core.Services.Request;

namespace GamesAPI.Repositories;
public class GameRepository : IGameRepository {
    private readonly IRepositoryHelper<Game> _repositoryHelper;
    private readonly BaseContext _db;
    public GameRepository(BaseContext db, IRepositoryHelper<Game> helper) {
        this._db = db;
        this._repositoryHelper = helper;
    }

    public async Task<IEnumerable<Game>> Get(RequestFilter[]? filters) {
        IQueryable<Game> gamesQuery = this._db.Games
            .Include(game => game.Platforms)
            .Include(game => game.SoftwareHouse)
            .Include(game => game.Category)
            .Include(game => game.Reviews)
        ;

        gamesQuery = this._repositoryHelper.ApplyFilters(gamesQuery, filters);
    
        List<Game> games = await gamesQuery.ToListAsync();

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
    
    public async Task Create(Game game) {
        await _db.Games.AddAsync(game);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Game game) {
        _db.Entry(game).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Game game) {
        _db.Games.Remove(game);
        await _db.SaveChangesAsync();
    }

}