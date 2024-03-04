using Microsoft.AspNetCore.Identity;

namespace GamesAPI.Core.Models;

public class Role : IdentityRole<int> {
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
