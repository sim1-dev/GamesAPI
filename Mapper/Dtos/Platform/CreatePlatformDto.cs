using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Dtos;

public class CreatePlatformDto {
    [Required(ErrorMessage = "Name required")]
    public required string Name { get; set; }
}
