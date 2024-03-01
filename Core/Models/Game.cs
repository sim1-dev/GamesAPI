using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Core.Models;
public class Game {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string Title {get; set;}

    public string Description {get; set;} = "";

    [Required]
    public required DateTime ReleaseDate {get; set;}

    public string? ImageUrl {get; set;} = "";

    [Required]
    public required decimal Price {get; set;}

    // TODO? change rate
    
    public List<Platform> Platforms {get; set;} = null!;

    [Required]
	public SoftwareHouse SoftwareHouse {get; set;} = null!;

    [Required]
    public Category Category {get; set;} = null!;

    public List<Review>? Reviews {get; set;}
    // public List<User>? Buyers { get; set; }
}