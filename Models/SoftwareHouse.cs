using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Models;
public class SoftwareHouse {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string Name {get; set;}

    public List<Developer>? Developers {get; set;}

    public List<Game>? Games {get; set;}
}