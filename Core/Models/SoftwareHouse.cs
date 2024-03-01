using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Core.Models;

[Table("softwarehouses")]
public class SoftwareHouse {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required]
    public required string Name {get; set;}

    public List<Developer>? Developers {get; set;}

    public List<Game>? Games {get; set;}
}