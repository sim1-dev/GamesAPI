using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class DeveloperProfile : Profile {
    public DeveloperProfile() {
        // CreateMap<CreatePlatformDto, Platform>();
        // CreateMap<UpdatePlatformDto, Platform>();
        CreateMap<Developer, DeveloperDto>()
            .ForMember(developerDto => developerDto.SoftwareHouseDto, option => option.MapFrom(developer => developer.SoftwareHouse))
        ;
    }
}