using GamesAPI.Core.Dtos;

namespace GamesAPI.Dtos;

public class ReviewDto {
    public int Id { get; set; }
    public required double Score { get; set; }
    public string? Comment { get; set; }
    public required UserDto ReviewerUserDto { get; set; }
    public required GameDto GameDto { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
