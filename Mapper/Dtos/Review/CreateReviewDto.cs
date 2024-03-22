using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Dtos;

public class CreateReviewDto {

    [Required(ErrorMessage = "Game required")]
    public required int GameId { get; set; }

    [Required(ErrorMessage = "Score required")]
    [Range(0, 10, ErrorMessage = "Score must be between 0-10")]
    public int Score { get; set; }

    [MaxLength(500)]
    public string? Comment {get; set;} = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}