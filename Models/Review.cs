using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GamesAPI.Core.Models;

namespace GamesAPI.Models;
public class Review {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;

    [Column("ReviewerUserId")]
    public int UserId { get; set; }

    public User ReviewerUser { get; set; } = null!;
    
    [Range(0, 10)]
    public int Score { get; set; }

    [MaxLength(500)]
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}