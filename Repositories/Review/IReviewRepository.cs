using GamesAPI.Models;

namespace GamesAPI.Repositories;

public interface IReviewRepository : IRepository<Review> {
    public Task<Review?> FindByReviewerUserIdAndGameId(int reviewerUserId, int gameId);
}