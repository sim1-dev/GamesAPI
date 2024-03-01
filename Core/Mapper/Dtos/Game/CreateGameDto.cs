namespace GamesAPI.Dtos;

public class CreateGameDto {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description {get; set;} = "";
    public DateTime ReleaseDate { get; set; }
    public string ImageUrl {get; set;} = "";
    public required decimal Price {get; set;}
    
    public required int PlatformId {get; set;}
    public required int SoftwareHouseId { get; set; }
}
