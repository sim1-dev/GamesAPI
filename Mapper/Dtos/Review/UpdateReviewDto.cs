using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Dtos;

public class UpdateReviewDto {

    [Range(0, 10, ErrorMessage = "Score must be between 0-10")]
    public int? Score { get; set; }

    [MaxLength(500)]
    public string? Comment {get; set;} = "";
}