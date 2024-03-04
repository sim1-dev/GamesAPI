using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

public class GameService {

    private readonly BaseContext _db;

    public GameService(BaseContext db) {
       this._db = db;
    }

    public async Task<List<Game>?> GetAll() {
        List<Game> games = await this._db.Games
            .Include(game => game.Platforms)
            .Include(game => game.SoftwareHouse)
            .Include(game => game.Reviews)  // TODO [perf] (non voglio caricare tutte le reviews per un'aggregazione)
        .ToListAsync();

        return games;
    }

    public async Task<Game?> Find(int id) {
        Game? game = await this._db.Games
            .Include(game => game.Platforms)
            .Include(game => game.SoftwareHouse)
            .Include(game => game.Reviews!)
                .ThenInclude(review => review.ReviewerUser)
        .FirstOrDefaultAsync(game => game.Id == id);
        
        return game;
    }

    public async Task<Game?> Create(Game game) {

        this._db.Games.Add(game);

        await this._db.SaveChangesAsync();

        return game;
    }

    public async Task<Game?> Update(int id, Game game) {

        Game? existingGame = await this.Find(id);

        if(existingGame is null)
            return null;

        this._db.Entry(existingGame).CurrentValues.SetValues(game);

        await this._db.SaveChangesAsync();

        return existingGame;
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