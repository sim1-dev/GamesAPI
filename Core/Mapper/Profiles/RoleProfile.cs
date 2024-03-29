using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Core.Dtos;

namespace GamesAPI.Core.Profiles;
class RoleProfile : Profile {
    public RoleProfile() {
        CreateMap<CreateRoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>()
            .ForAllMembers(opts => opts.Condition((updateRoleDto, role, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
            ))
        ;
        CreateMap<Role, RoleDto>();
        CreateMap<Role, RoleDetailDto>()
            .ForMember(roleDetailDto => roleDetailDto.UserDtos, opt => opt.MapFrom(role => role.Users))
        ;
    }
}