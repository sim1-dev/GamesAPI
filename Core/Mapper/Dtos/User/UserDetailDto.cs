namespace GamesAPI.Dtos;

public class UserDetailDto: UserDto {
    public List<DeveloperDto>? DeveloperDtos { get; set; }
}
