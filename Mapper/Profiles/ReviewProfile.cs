using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Profiles;
class ReviewProfile : Profile {
    public ReviewProfile() {
        CreateMap<CreateReviewDto, Review>();
        CreateMap<UpdateReviewDto, Review>()
            .ForAllMembers(opts => opts.Condition((updateReviewDto, review, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
            ));
        ;

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