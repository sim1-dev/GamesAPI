using GamesAPI.Core.Dtos;
using GamesAPI.Core.Models;

namespace GamesAPI.Core.Services;

public interface IRoleService : IService<Role, CreateRoleDto, UpdateRoleDto> {
}