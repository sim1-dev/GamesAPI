namespace GamesAPI.Dtos;

public class UserDto {
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public List<DeveloperDto>? DeveloperDtos { get; set; }
}
