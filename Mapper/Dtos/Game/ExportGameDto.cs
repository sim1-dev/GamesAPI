namespace GamesAPI.Dtos;

public class ExportGameDto {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description {get; set;} = "";
    public DateTime ReleaseDate { get; set; }
    public required decimal Price {get; set;}
    
    public string Platforms {get; set;} = "";
    public required string SoftwareHouse { get; set; }
    public required string Category { get; set; }

    public int? ReviewsAvgScore {get; set;}
}
