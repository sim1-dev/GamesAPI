using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

public interface IReviewService : IService<Review, CreateReviewDto, UpdateReviewDto> {
    public Task<Review?> FindByReviewerUserIdAndGameId(int reviewerUserId, int gameId);
    public Task<Review> CreateForUser(CreateReviewDto createReviewDto, int userId);
}