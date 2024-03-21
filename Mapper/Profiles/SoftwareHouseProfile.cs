using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Profiles;
class SoftwareHouseProfile : Profile {
    public SoftwareHouseProfile() {
        CreateMap<CreateSoftwareHouseDto, SoftwareHouse>();
        CreateMap<UpdateSoftwareHouseDto, SoftwareHouse>();
        CreateMap<SoftwareHouse, SoftwareHouseDto>();
        
        CreateMap<SoftwareHouse, SoftwareHouseDetailDto>()
            .ForMember(softwareHouseDetailDto => softwareHouseDetailDto.DeveloperDtos, option => option.MapFrom(softwareHouse => softwareHouse.Developers))
        ;
    }
}