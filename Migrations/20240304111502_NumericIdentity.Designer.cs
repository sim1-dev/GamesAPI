﻿// <auto-generated />
using System;
using GamesAPI.Core.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamesAPI.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20240304111502_NumericIdentity")]
    partial class NumericIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("GamePlatform");

                    b.HasData(
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 4
                        },
                        new
                        {
                            GamesId = 2,
                            PlatformsId = 4
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shooter"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Arcade"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Platformer"
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SoftwareHouseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareHouseId");

                    b.HasIndex("UserId");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SoftwareHouseId = 1,
                            UserId = 1,
                            Username = "sim1-dev"
                        },
                        new
                        {
                            Id = 2,
                            SoftwareHouseId = 1,
                            UserId = 2,
                            Username = "andreasssss"
                        },
                        new
                        {
                            Id = 3,
                            SoftwareHouseId = 2,
                            UserId = 3,
                            Username = "johnSmith15"
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SoftwareHouseId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SoftwareHouseId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Developed by the creators of Grand Theft Auto V and Red Dead Redemption, Red Dead Redemption 2 is an epic tale of life in America's unforgiving heartland.",
                            Price = 79.99m,
                            ReleaseDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoftwareHouseId = 1,
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "The Last of Us Part II is a 2020 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment.",
                            Price = 59.99m,
                            ReleaseDate = new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoftwareHouseId = 8,
                            Title = "The Last of Us Part II"
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Windows"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Linux"
                        },
                        new
                        {
                            Id = 3,
                            Name = "MacOS"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Playstation 5"
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("ReviewerUserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "This game is awesome!",
                            CreatedAt = new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3066),
                            GameId = 1,
                            Score = 9,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Pretty good game, but gets boring after the main questline",
                            CreatedAt = new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3149),
                            GameId = 1,
                            Score = 7,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Comment = "I loved this game!",
                            CreatedAt = new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3152),
                            GameId = 2,
                            Score = 10,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Comment = "I didn't like this game at all...",
                            CreatedAt = new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3153),
                            GameId = 1,
                            Score = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("GamesAPI.Core.Models.SoftwareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SoftwareHouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rockstar Games"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ubisoft"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Activision"
                        },
                        new
                        {
                            Id = 4,
                            Name = "EA"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Square Enix"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bethesda"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Microsoft"
                        });
                });

            modelBuilder.Entity("GamesAPI.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "39d6a80e-bef9-4cbb-8c9d-5e94a69fef07",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEP7dzuCTQ8gzODCQjSBRHTjZiklWAUCkmh5t0t3sLZkxTDArY0otc6NahbGGq93CUw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "84bdfcd0-d8ea-4942-af7c-cca9ccbd6ae1",
                            Email = "and.rea@test.com",
                            EmailConfirmed = true,
                            FirstName = "Andrea",
                            LastName = "Test",
                            LockoutEnabled = false,
                            NormalizedEmail = "AND.REA@TEST.COM",
                            NormalizedUserName = "AND_REA",
                            PasswordHash = "AQAAAAIAAYagAAAAEMIinxXBhIoRY32VGHJPwpXpBQ7+QxReqQxBls+hSuZl9ASdMr9PGi2hSBSnK8Jo4g==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "and_rea"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "177d97fa-1a05-40cf-ae34-60b56db51778",
                            Email = "john.smith@test.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "JOHN.SMITH@TEST.COM",
                            NormalizedUserName = "JOHNSMITH15",
                            PasswordHash = "AQAAAAIAAYagAAAAEPWRWy1mj9iGySKvvmY2VmfmOuHiKnVgCbSnA3nxhgY6YB1KhldsHQsjI0PlQVh0MQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "johnSmith15"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole<int>");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesAPI.Core.Models.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Developer", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.SoftwareHouse", "SoftwareHouse")
                        .WithMany("Developers")
                        .HasForeignKey("SoftwareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesAPI.Core.Models.User", "User")
                        .WithMany("DeveloperAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareHouse");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Game", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesAPI.Core.Models.SoftwareHouse", "SoftwareHouse")
                        .WithMany("Games")
                        .HasForeignKey("SoftwareHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SoftwareHouse");
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Review", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.Game", null)
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesAPI.Core.Models.User", "ReviewerUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReviewerUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesAPI.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("GamesAPI.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesAPI.Core.Models.Game", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GamesAPI.Core.Models.SoftwareHouse", b =>
                {
                    b.Navigation("Developers");

                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesAPI.Core.Models.User", b =>
                {
                    b.Navigation("DeveloperAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
