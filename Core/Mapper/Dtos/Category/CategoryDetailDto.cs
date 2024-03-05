namespace GamesAPI.Dtos;

public class CategoryDetailDto : CategoryDto {
    public List<GameDto>? GameDtos { get; set; }
}