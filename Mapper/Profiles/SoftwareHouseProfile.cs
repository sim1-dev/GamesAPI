using AutoMapper;
using GamesAPI.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Profiles;
class SoftwareHouseProfile : Profile {
    public SoftwareHouseProfile() {
        CreateMap<CreateSoftwareHouseDto, SoftwareHouse>();
        CreateMap<UpdateSoftwareHouseDto, SoftwareHouse>()
            .ForAllMembers(opts => opts.Condition((updateSoftwareHouseDto, softwareHouse, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
            ));
        ;
        CreateMap<SoftwareHouse, SoftwareHouseDto>();
        
        CreateMap<SoftwareHouse, SoftwareHouseDetailDto>()
            .ForMember(softwareHouseDetailDto => softwareHouseDetailDto.DeveloperDtos, option => option.MapFrom(softwareHouse => softwareHouse.Developers))
        ;
    }
}