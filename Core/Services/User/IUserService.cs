using GamesAPI.Core.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Core.Services;

public interface IUserService : IService<User, CreateUserDto, UpdateUserDto> {
}