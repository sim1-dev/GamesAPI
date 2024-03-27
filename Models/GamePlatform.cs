using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Models;
[Table("gameplatforms")]
public class GamePlatform {
    public int GameId { get; set; }
    public int PlatformId { get; set; }
}