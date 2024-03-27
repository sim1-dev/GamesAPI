using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Core.Dtos;

namespace GamesAPI.Core.Profiles;
class UserProfile : Profile {
    public UserProfile() {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>()
            .ForAllMembers(opts => opts.Condition((updateUserDto, user, srcMember) => 
                srcMember != null
                && srcMember.ToString() != "0"
                && srcMember.ToString() != new DateTime().ToString()
            ))
        ;
        CreateMap<User, UserDto>();
        CreateMap<User, UserDetailDto>()
            .ForMember(userDetailDto => userDetailDto.DeveloperDtos, opt => opt.MapFrom(user => user.DeveloperAccounts))
        ;
    }
}