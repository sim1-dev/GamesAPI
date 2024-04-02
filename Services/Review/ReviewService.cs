using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Repositories;
using GamesAPI.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Services;

public class ReviewService : IReviewService {
    private readonly IReviewRepository _reviewRepository;

    private readonly IMapper _mapper;

    public ReviewService(IReviewRepository reviewRepository, IMapper mapper) {
        this._reviewRepository = reviewRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<Review>> Get(RequestFilter[]? filters, RequestOrder? order, RequestPagination? pagination) {
        IEnumerable<Review> reviews = await this._reviewRepository.Get(filters, order, pagination);
        return reviews;
    }
    
    public async Task<Review?> Find(int id) {
        Review? review = await this._reviewRepository.Find(id);

        return review;
    }

    public async Task<Review?> FindByReviewerUserIdAndGameId(int reviewerUserId, int gameId) {
        Review? review = await this._reviewRepository.FindByReviewerUserIdAndGameId(reviewerUserId, gameId);

        return review;
    }

    public async Task<Review> Create(CreateReviewDto createReviewDto) {
        Review review = this._mapper.Map<Review>(createReviewDto);

        await this._reviewRepository.Create(review);

        return review;
    }

    public async Task<Review> CreateForUser(CreateReviewDto createReviewDto, int userId) {
        Review review = _mapper.Map<Review>(createReviewDto);

        review.UserId = userId;

        await this._reviewRepository.Create(review);

        return review;
    }

    public async Task<Review?> Update(int id, UpdateReviewDto updateReviewDto) {
        Review? review = await this._reviewRepository.Find(id);

        if(review is null)
            return null;

        Review updatedReview = _mapper.Map(updateReviewDto, review);

        await this._reviewRepository.Update(updatedReview);

        return review;
    }

    public async Task<bool> Delete(int id) {
        Review? review = await this._reviewRepository.Find(id);

        if(review is null)
            return false;

        await this._reviewRepository.Delete(review);

        return true;
    }
}