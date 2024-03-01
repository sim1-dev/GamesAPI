using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Dtos;

public class CreateGameDto {
    [Required(ErrorMessage = "Title required")]
    public required string Title { get; set; }
    public string Description {get; set;} = "";
    public DateTime ReleaseDate { get; set; }
    public string ImageUrl {get; set;} = "";

    [Required(ErrorMessage = "Price required")]
    public required decimal Price {get; set;}

    [Required(ErrorMessage = "Software House required")]
    public required int SoftwareHouseId { get; set; }

    [Required(ErrorMessage = "Category required")]
    public required int CategoryId { get; set; }
}
