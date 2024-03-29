using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GamesAPI.Core.Models;

namespace GamesAPI.Models;
public class Developer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public SoftwareHouse SoftwareHouse { get; set; } = null!;

    public int SoftwareHouseId { get; set; }
}