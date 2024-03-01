namespace GamesAPI.Dtos;

public class DeveloperDto {
    public int Id { get; set; }
    public required string Username { get; set; }

    public required UserDto UserDto { get; set; } = null!;
    
    public required SoftwareHouseDto SoftwareHouseDto { get; set; } = null!;
}
