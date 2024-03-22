namespace GamesAPI.Dtos;

public class UpdateGameDto {
    public string? Title { get; set; }
    public string? Description {get; set;}
    public DateTime? ReleaseDate { get; set; }
    public string? ImageUrl {get; set;}
    public decimal? Price {get; set;}
    public int? SoftwareHouseId { get; set; }
}
