using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class PlatformProfile : Profile {
    public PlatformProfile() {
        CreateMap<CreatePlatformDto, Platform>();
        CreateMap<UpdatePlatformDto, Platform>();
        CreateMap<Platform, PlatformDto>();
        CreateMap<Platform, PlatformDetailDto>()
            .ForMember(platformDetailDto => platformDetailDto.GameDtos, opt => opt.MapFrom(platform => platform.Games))
        ;
    }
}