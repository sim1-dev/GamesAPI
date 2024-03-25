using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Profiles;
class DeveloperProfile : Profile {
    public DeveloperProfile() {
        CreateMap<CreateDeveloperDto, Developer>();
        CreateMap<CreateDeveloperForUserDto, Developer>();

        CreateMap<CreateDeveloperForUserDto, CreateDeveloperDto>();

        CreateMap<UpdateDeveloperDto, Developer>()
            .ForAllMembers(opts => opts.Condition((updateDeveloperDto, developer, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
                && srcMember.ToString() != new List<int>().ToString()
            ))
        ;
        CreateMap<Developer, DeveloperDto>();
        CreateMap<Developer, DeveloperDetailDto>()
            .ForMember(developerDto => developerDto.UserDto, option => option.MapFrom(developer => developer.User))
            .ForMember(developerDto => developerDto.SoftwareHouseDto, option => option.MapFrom(developer => developer.SoftwareHouse))
        ;
    }
}