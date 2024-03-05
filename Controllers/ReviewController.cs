using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;
using GamesAPI.Services;
using GamesAPI.Core.Services;

namespace GamesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ReviewService _reviewService;

    private readonly UserContextService _userContextService;

    public ReviewController(IMapper mapper, ReviewService reviewService, UserContextService userContextService) {
        this._mapper = mapper;
        this._reviewService = reviewService;
        this._userContextService = userContextService;
    }
    
    [AllowAnonymous]
	[HttpGet]
    public async Task<ActionResult<Collection<ReviewDto>>> Get() {
        List<Review>? reviews = await this._reviewService.GetAll();

        if(reviews is null)
            return NotFound();

        List<ReviewDto> reviewDtos = _mapper.Map<List<ReviewDto>>(reviews);

        return Ok(reviewDtos);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDetailDto>> Find(int id) {
        Review? review = await this._reviewService.Find(id);

        if(review is null)
            return NotFound();

        ReviewDetailDto reviewDetailDto = _mapper.Map<ReviewDetailDto>(review);

        return Ok(reviewDetailDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> Create(CreateReviewDto createReviewDto) {
        if(createReviewDto is null)
            return BadRequest();

        int userId = _userContextService.GetUserId();


        Review? existingReviewOnGame = await this._reviewService.FindByReviewerUserIdAndGameId(userId, createReviewDto.GameId);

        if(existingReviewOnGame is not null)
            return BadRequest("A review already exists for this game by this user");


        Review review = await this._reviewService.CreateForUser(createReviewDto, userId);
            
        ReviewDto reviewDto = _mapper.Map<ReviewDto>(review);

        return reviewDto;
    }

    [Authorize(Policy = "IsReviewerUser")]
    [HttpPut("{id}")]
    public async Task<ActionResult<ReviewDto>> Update(int id, [FromBody] UpdateReviewDto updateReviewDto) {
        if(updateReviewDto is null)
            return BadRequest();

        Review? updatedReview = await this._reviewService.Update(id, updateReviewDto);

        if(updatedReview is null)
            return StatusCode(500, "An error has occurred while updating. Please contact the system administrator");      

        ReviewDto updatedReviewDto = _mapper.Map<ReviewDto>(updatedReview);

        return updatedReviewDto;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ReviewDto>> Delete(int id) {
            
        Review? review = await this._reviewService.Delete(id);

        if(review is null)
            return NotFound();

        return Ok();
    }
}
