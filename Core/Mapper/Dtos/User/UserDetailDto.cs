using GamesAPI.Dtos;

namespace GamesAPI.Core.Dtos;

public class UserDetailDto: UserDto {
    public List<DeveloperDto>? DeveloperDtos { get; set; }
}
