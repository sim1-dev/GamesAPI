using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Core.Models;

[Table("reviews")]
public class Review {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("game_id")]
    public int GameId { get; set; }

    [Column("reviewer_user_id")]
    public int UserId { get; set; }

    [Column("score")]
    [Range(0, 10)]
    public int Score { get; set; }

    [Column("comment")]
    [MaxLength(500)]
    public string? Comment { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}