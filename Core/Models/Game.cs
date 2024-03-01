using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Core.Models;

[Table("games")]
public class Game {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [Required]
    public required string Title {get; set;}

    [Column("description")]
    public string Description {get; set;} = "";

    [Column("release_date")]
    [Required]
    public required DateTime ReleaseDate {get; set;}

    [Column("image_url")]
    public string? ImageUrl {get; set;} = "";

    [Column("price")]
    [Required]
    public required decimal Price {get; set;}

    // TODO? change rate
    
    public List<Platform> Platforms {get; set;} = null!;

    [ForeignKey("softwarehouse_id")]
    [Required]
	public SoftwareHouse SoftwareHouse {get; set;} = null!;

    [ForeignKey("category_id")]
    [Required]
    public Category Category {get; set;} = null!;

    public List<Review>? Reviews {get; set;}
    // public List<User>? Buyers { get; set; }
}