using GamesAPI.Core.DataContexts;
using GamesAPI.Models;
using GamesAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories;
public class ReviewRepository : IReviewRepository {
    private readonly BaseContext _db;
    public ReviewRepository(BaseContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<Review>> GetAll() {
        return await _db.Reviews
            .Include(review => review.ReviewerUser)
            .Include(review => review.Game)
        .ToListAsync();
    }

    public async Task<Review?> Find(int id) {
        Review? review = await _db.Reviews
            .Include(review => review.ReviewerUser)
            .Include(review => review.Game)
                .ThenInclude(game => game.Platforms)
            .Include(review => review.Game)
                .ThenInclude(game => game.SoftwareHouse)
            .Include(review => review.Game)
                .ThenInclude(game => game.Category)
        .FirstOrDefaultAsync(review => review.Id == id);

        return review;
    }

    public async Task<Review?> FindByReviewerUserIdAndGameId(int reviewerUserId, int gameId) {
        Review? review = await _db.Reviews.FirstOrDefaultAsync(review => review.UserId == reviewerUserId && review.GameId == gameId);

        return review;
    }
    
    public async Task Create(Review review) {
        await _db.Reviews.AddAsync(review);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Review review) {
        _db.Entry(review).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Review review) {
        _db.Reviews.Remove(review);
        await _db.SaveChangesAsync();
    }

}