using GamesAPI.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;

namespace GamesAPI.Services;

public interface IReviewService : IService<Review, CreateReviewDto, UpdateReviewDto> {
    public Task<Review?> FindByReviewerUserIdAndGameId(int reviewerUserId, int gameId);
    public Task<Review> CreateForUser(CreateReviewDto createReviewDto, int userId);
}