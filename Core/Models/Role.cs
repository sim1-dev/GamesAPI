using Microsoft.AspNetCore.Identity;

namespace GamesAPI.Core.Models;

public class Role : IdentityRole<int> {

    public override int Id { get; set; }

    //public virtual ICollection<User> Users { get; set; } = new List<User>();
}
