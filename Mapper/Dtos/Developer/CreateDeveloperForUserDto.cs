namespace GamesAPI.Dtos;

public class CreateDeveloperForUserDto {
    public required string Username { get; set; }
    public required int SoftwareHouseId { get; set; }
}
