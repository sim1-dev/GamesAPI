namespace GamesAPI.Dtos;

public class ReviewDto {
    public int Id { get; set; }
    public required double Score { get; set; }
    public string? Comment { get; set; }
    public required UserDto UserDto { get; set; }
}
