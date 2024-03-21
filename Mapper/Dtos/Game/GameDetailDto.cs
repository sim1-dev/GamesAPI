namespace GamesAPI.Dtos;

public class GameDetailDto : GameDto {
   public List<ReviewDto>? ReviewDtos { get; set; }
}
