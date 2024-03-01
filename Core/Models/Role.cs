using Microsoft.AspNetCore.Identity;

namespace GamesAPI.Core.Models; // TODO move mapper, derived models folders out of core

public class Role : IdentityRole<int> {
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
