using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class ReviewProfile : Profile {
    public ReviewProfile() {
        CreateMap<CreateReviewDto, Review>();
        CreateMap<UpdateReviewDto, Review>();

        CreateMap<Review, ReviewDto>()
            .ForMember(reviewDto => reviewDto.ReviewerUserDto, opt => opt.MapFrom(review => review.ReviewerUser))
            .ForMember(reviewDto => reviewDto.GameDto, opt => opt.MapFrom(review => review.Game))
        ;

        CreateMap<Review, ReviewDetailDto>()
            .ForMember(reviewDto => reviewDto.ReviewerUserDto, opt => opt.MapFrom(review => review.ReviewerUser))
            .ForMember(reviewDto => reviewDto.GameDto, opt => opt.MapFrom(review => review.Game))
        ;
    }
}