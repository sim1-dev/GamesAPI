using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Dtos;

public class CreateCategoryDto {
    [Required(ErrorMessage = "Name required")]
    public required string Name { get; set; }
}
