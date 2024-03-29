namespace GamesAPI.Core.Dtos;

public class RoleDetailDto : RoleDto {
    public virtual List<UserDto> UserDtos { get; set; } = new List<UserDto>();
}
