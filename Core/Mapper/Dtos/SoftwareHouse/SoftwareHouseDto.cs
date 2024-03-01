namespace GamesAPI.Dtos;

public class SoftwareHouseDto {
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<DeveloperDto>? DeveloperDtos { get; set; }
}
