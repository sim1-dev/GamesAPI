using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GamesAPI.Core.Models;
using GamesAPI.Models;

namespace GamesAPI.Core.DataContexts;

public class BaseContext : IdentityDbContext<User, Role, int> {

    private readonly PasswordHasher<User> _passwordHasher;

    public BaseContext(DbContextOptions<BaseContext> options, PasswordHasher<User> passwordHasher) : base(options){
        this._passwordHasher = passwordHasher;
    }

    // Authorization
    public new DbSet<User> Users {get; set;}
    public new DbSet<Role> Roles {get; set;}

    // Discriminators
    public DbSet<Platform> Platforms {get; set;}
    public DbSet<Category> Categories {get; set;}

    // Development area
    public DbSet<SoftwareHouse> SoftwareHouses {get; set;}
    public DbSet<Developer> Developers {get; set;}

    // Game related entities
    public DbSet<Game> Games {get; set;}
    public DbSet<Review> Reviews {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        seed(modelBuilder);
    }

    private void seed(ModelBuilder modelBuilder) {

        seedUsers(modelBuilder);
        seedRoles(modelBuilder);

        seedUserRoles(modelBuilder);

        seedSoftwareHouses(modelBuilder);
        seedDevelopers(modelBuilder);

        seedPlatforms(modelBuilder);
        seedCategories(modelBuilder);

        seedGames(modelBuilder);

        seedGamePlatforms(modelBuilder);

        seedReviews(modelBuilder);
    }

    private void seedUsers(ModelBuilder modelBuilder) {

        modelBuilder.Entity<User>().HasData(
            new User { 
                Id = 1, 
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@rockstargames.com", 
                NormalizedUserName = "ADMIN@ROCKSTARGAMES.COM", 
                Email = "admin@rockstargames.com", 
                NormalizedEmail = "ADMIN@ROCKSTARGAMES.COM", 
                EmailConfirmed = true,
                PasswordHash = this._passwordHasher.HashPassword(null!, "Password1!"),
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new User { 
                Id = 2, 
                FirstName = "Andrea",
                LastName = "Test",
                UserName = "and.rea@rockstargames.com", 
                NormalizedUserName = "AND.REA@ROCKSTARGAMES.COM", 
                Email = "and.rea@rockstargames.com", 
                NormalizedEmail = "AND.REA@ROCKSTARGAMES.COM", 
                EmailConfirmed = true,
                PasswordHash = this._passwordHasher.HashPassword(null!, "Password1!"),
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new User { 
                Id = 3, 
                FirstName = "John",
                LastName = "Smith",
                UserName = "john.smith@ubisoft.com", 
                NormalizedUserName = "JOHN.SMITH@UBISOFT.COM", 
                Email = "john.smith@ubisoft.com", 
                NormalizedEmail = "JOHN.SMITH@UBISOFT.COM", 
                EmailConfirmed = true,
                PasswordHash = this._passwordHasher.HashPassword(null!, "Password1!"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );
    }

    private void seedRoles(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Id = 2, Name = "User", NormalizedName = "USER" }
        );
    }

    private void seedUserRoles(ModelBuilder modelBuilder) {
        modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int> { RoleId = 1, UserId = 1 },
            new IdentityUserRole<int> { RoleId = 2, UserId = 2 },
            new IdentityUserRole<int> { RoleId = 2, UserId = 3 }
        );
    }
    
    private void seedSoftwareHouses(ModelBuilder modelBuilder) {
        modelBuilder.Entity<SoftwareHouse>().HasData(
            new SoftwareHouse { Id = 1, Name = "Rockstar Games" },
            new SoftwareHouse { Id = 2, Name = "Ubisoft" },
            new SoftwareHouse { Id = 3, Name = "Activision" },
            new SoftwareHouse { Id = 4, Name = "EA" },
            new SoftwareHouse { Id = 5, Name = "Nintendo" },
            new SoftwareHouse { Id = 6, Name = "Square Enix" },
            new SoftwareHouse { Id = 7, Name = "Bethesda" },
            new SoftwareHouse { Id = 8, Name = "Sony" },
            new SoftwareHouse { Id = 9, Name = "Microsoft" }
        );
    }

    public void seedDevelopers(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Developer>().HasData(
            new { 
                Id = 1, 
                Username = "sim1-dev",
                UserId = 1,
                SoftwareHouseId = 1,
            },
            new { 
                Id = 2, 
                Username = "andreasssss",
                UserId = 2,
                SoftwareHouseId = 1,
            },
            new { 
                Id = 3, 
                Username = "johnSmith15",
                UserId = 3,
                SoftwareHouseId = 2,
            }
        );
    }

    public void seedPlatforms(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Platform>().HasData(
            new Platform { Id = 1, Name = "Windows" },
            new Platform { Id = 2, Name = "Linux" },
            new Platform { Id = 3, Name = "MacOS" },
            new Platform { Id = 4, Name = "Playstation 5" }
	    );
    }

    public void seedCategories(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action" },
            new Category { Id = 2, Name = "Adventure" },
            new Category { Id = 3, Name = "RPG" },
            new Category { Id = 4, Name = "Shooter" },
            new Category { Id = 5, Name = "Simulation" },
            new Category { Id = 6, Name = "Sports" },
            new Category { Id = 7, Name = "Strategy" },
            new Category { Id = 8, Name = "Puzzle" },
            new Category { Id = 9, Name = "Racing" },
            new Category { Id = 10, Name = "Fighting" },
            new Category { Id = 11, Name = "Arcade" },
            new Category { Id = 12, Name = "Platformer" }
        );
    }
    public void seedGames(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Game>().HasData(
            new { 
                Id = 1, 
                Title = "Red Dead Redemption 2", 
                Description = "Developed by the creators of Grand Theft Auto V and Red Dead Redemption, Red Dead Redemption 2 is an epic tale of life in America's unforgiving heartland.", 
                ReleaseDate = new DateTime(2018, 10, 26), 
                Price = 79.99M,
                CategoryId = 1,
                SoftwareHouseId = 1,
            },
            new { 
                Id = 2, 
                Title = "The Last of Us Part II", 
                Description = "The Last of Us Part II is a 2020 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment.", 
                ReleaseDate = new DateTime(2020, 08, 11), 
                Price = 59.99M,
                CategoryId = 2, 
                SoftwareHouseId = 8 
            }
        );
    }

    public void seedGamePlatforms(ModelBuilder modelBuilder) {
        modelBuilder.Entity("GamePlatform").HasData(
            new { GamesId = 1, PlatformsId = 1 },
            new { GamesId = 1, PlatformsId = 2 },
            new { GamesId = 1, PlatformsId = 4 },
            new { GamesId = 2, PlatformsId = 4 }
        );
    }

    public void seedReviews(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Review>().HasData(
            new Review { 
                Id = 1, 
                GameId = 1, 
                UserId = 1, 
                Score = 9, 
                Comment = "This game is awesome!" 
            },
            new Review { 
                Id = 2, 
                GameId = 1, 
                UserId = 2, 
                Score = 7, 
                Comment = "Pretty good game, but gets boring after the main questline" 
            },
            new Review { 
                Id = 3, 
                GameId = 2, 
                UserId = 1, 
                Score = 10, 
                Comment = "I loved this game!" 
            },
            new Review { 
                Id = 4, 
                GameId = 1, 
                UserId = 2,
                Score = 1,
                Comment = "I didn't like this game at all..." 
            }
        );

    }

}
