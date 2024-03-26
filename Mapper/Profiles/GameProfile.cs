using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Profiles;
class GameProfile : Profile {
    public GameProfile() {
        CreateMap<CreateGameDto, Game>();
        CreateMap<UpdateGameDto, Game>()
            .ForAllMembers(opts => opts.Condition((updateGameDto, game, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
                && srcMember.ToString() != new List<int>().ToString()
            ));
        ;

        CreateMap<Game, UpdateGameDto>()
            .ForAllMembers(opts => opts.Condition((game, updateGameDto, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
                && srcMember.ToString() != new List<int>().ToString()
            ));
        ;

        CreateMap<Game, GameDto>()
            .ForMember(gameDto => gameDto.SoftwareHouseDto, option => option.MapFrom(game => game.SoftwareHouse))
            .ForMember(gameDetailDto => gameDetailDto.CategoryDto, option => option.MapFrom(game => game.Category))
            .ForMember(gameDto => gameDto.PlatformDtos, option => option.MapFrom(game => game.Platforms))
            .ForMember(gameDto => gameDto.ReviewsAvgScore, opt => opt.MapFrom(
                    game => game.Reviews != null && game.Reviews.Any() 
                        ? game.Reviews.Average(review => review.Score) 
                        : 0
                )
            )
        ;
        
        CreateMap<Game, GameDetailDto>()
            .ForMember(gameDetailDto => gameDetailDto.SoftwareHouseDto, option => option.MapFrom(game => game.SoftwareHouse))
            .ForMember(gameDetailDto => gameDetailDto.CategoryDto, option => option.MapFrom(game => game.Category))
            .ForMember(gameDetailDto => gameDetailDto.PlatformDtos, option => option.MapFrom(game => game.Platforms))
            .ForMember(gameDetailDto => gameDetailDto.ReviewDtos, option => option.MapFrom(game => game.Reviews))
        ;
    }
}