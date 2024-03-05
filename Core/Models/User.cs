using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GamesAPI.Core.Models;

[Table("users")]
public class User : IdentityUser<int> {

    public override int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Developer>? DeveloperAccounts { get; set; }
    public List<Review>? Reviews;
}