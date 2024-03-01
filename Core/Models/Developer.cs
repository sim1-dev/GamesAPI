using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Core.Models;

[Table("developers")]
public class Developer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("username")]
    public string Username { get; set; } = null!;
    
    [ForeignKey("user_id")]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [ForeignKey("softwarehouse_id")]
    [Required]
    public SoftwareHouse SoftwareHouse { get; set; } = null!;
}