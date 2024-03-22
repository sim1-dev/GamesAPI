using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Profiles;
class PlatformProfile : Profile {
    public PlatformProfile() {
        CreateMap<CreatePlatformDto, Platform>();
        CreateMap<UpdatePlatformDto, Platform>()
            .ForAllMembers(opts => opts.Condition((updatePlatformDto, platform, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
            ));
        ;
        CreateMap<Platform, PlatformDto>();
        CreateMap<Platform, PlatformDetailDto>()
            .ForMember(platformDetailDto => platformDetailDto.GameDtos, opt => opt.MapFrom(platform => platform.Games))
        ;
    }
}