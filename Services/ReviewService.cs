using AutoMapper;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Core.Services;
using GamesAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Services;

public class ReviewService : ICrudService<Review, ReviewDto, CreateReviewDto, UpdateReviewDto> {

    private readonly BaseContext _db;
    private readonly IMapper _mapper;
    public ReviewService(BaseContext db, IMapper mapper, UserContextService userContextService) {
       this._db = db;
       this._mapper = mapper;
    }

    public async Task<List<Review>> GetAll() {
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

    public async Task<Review> Create(CreateReviewDto createReviewDto) {
        Review review = _mapper.Map<Review>(createReviewDto);

        this._db.Reviews.Add(review);

        await _db.SaveChangesAsync();

        return review;
    }

    public async Task<Review> CreateForUser(CreateReviewDto createReviewDto, int userId) {
        Review review = _mapper.Map<Review>(createReviewDto);

        review.UserId = userId;

        this._db.Reviews.Add(review);

        await _db.SaveChangesAsync();

        return review;
    }

    public async Task<Review?> Update(int id, UpdateReviewDto updateReviewDto) {

        Review? review = await this.Find(id);

        if(review is null)
            return null;

        this._mapper.Map(updateReviewDto, review);

        await this._db.SaveChangesAsync();

        return review;
    }

    public async Task<Review?> Delete(int id) {
        Review? review = await this.Find(id);

        if(review is null)
            return null;

        this._db.Reviews.Remove(review);

        await this._db.SaveChangesAsync();

        return review;
    }

}