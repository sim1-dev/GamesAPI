namespace GamesAPI.Core.Dtos;

public class CreateUserDto {
    public required string Email { get; set; }
    public string Password { get; set; } = null!;

    
    public string Username { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
