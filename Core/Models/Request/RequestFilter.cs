using System.ComponentModel.DataAnnotations;

namespace GamesAPI.Core.Models;

public class RequestFilter {
    [Required]
    public required string Field { get; set; }
    [Required]
    public required string Value { get; set; }
    [Required]
    public required string Operation { get; set; }
}
