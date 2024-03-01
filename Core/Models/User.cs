using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GamesAPI.Core.Models;

[Table("users")]
public class User : IdentityUser<int> {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Developer>? DeveloperAccounts { get; set; }
    public List<Review>? Reviews;

    //public List<Game>? OwnedGames { get; set; }
}