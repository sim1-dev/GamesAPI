using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class ReviewProfile : Profile {
    public ReviewProfile() {
        // CreateMap<CreateReviewDto, Review>();
        // CreateMap<UpdateReviewDto, Review>();
        CreateMap<Review, ReviewDto>()
            .ForMember(reviewDto => reviewDto.UserDto, opt => opt.MapFrom(review => review.ReviewerUser));
    }
}