using AutoMapper;
using GamesAPI.Core.Models;
using GamesAPI.Dtos;

namespace GamesAPI.Utilities;
class UserProfile : Profile {
    public UserProfile() {
        // CreateMap<CreateUserDto, User>();
        // CreateMap<UpdateUserDto, User>();
        CreateMap<User, UserDto>();
    }
}