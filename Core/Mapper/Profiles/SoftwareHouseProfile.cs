using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class SoftwareHouseProfile : Profile {
    public SoftwareHouseProfile() {
        // CreateMap<CreateSoftwareHouseDto, SoftwareHouse>();
        // CreateMap<UpdateSoftwareHouseDto, SoftwareHouse>();
        CreateMap<SoftwareHouse, SoftwareHouseDto>();
        CreateMap<SoftwareHouse, SoftwareHouseDetailDto>()
            .ForMember(softwareHouseDetailDto => softwareHouseDetailDto.DeveloperDtos, option => option.MapFrom(softwareHouse => softwareHouse.Developers))
        ;
    }
}