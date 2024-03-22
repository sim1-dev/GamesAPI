using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories;
public class GameRepository : IGameRepository {
    private readonly BaseContext _db;
    public GameRepository(BaseContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<Game>> GetAll() {
        IEnumerable<Game> games = await this._db.Games
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