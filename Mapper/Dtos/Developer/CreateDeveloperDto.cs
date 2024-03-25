namespace GamesAPI.Dtos;

public class CreateDeveloperDto : CreateDeveloperForUserDto {
    public required int UserId { get; set; }
}
