namespace GamesAPI.Dtos;

public class GameDto {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description {get; set;} = "";
    public DateTime ReleaseDate { get; set; }
    public required string ImageUrl {get; set;}
    public required decimal Price {get; set;}
    
    public required List<PlatformDto> PlatformDtos {get; set;}
    public required SoftwareHouseDto SoftwareHouseDto { get; set; }

    public int? ReviewsAvgScore {get; set;}
}
