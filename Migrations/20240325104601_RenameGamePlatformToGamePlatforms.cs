using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameGamePlatformToGamePlatforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Games_GameId",
                table: "GamePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformId",
                table: "GamePlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlatform",
                table: "GamePlatform");

            migrationBuilder.RenameTable(
                name: "GamePlatform",
                newName: "gameplatforms");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlatform_PlatformId",
                table: "gameplatforms",
                newName: "IX_gameplatforms_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gameplatforms",
                table: "gameplatforms",
                columns: new[] { "GameId", "PlatformId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60c03682-e48a-41ed-a5cd-e9e5cdb742bb", "AQAAAAIAAYagAAAAECwCbaouZV0HCQJnSFBV6bb+JVofKyzktPKARY2+5GYuo+rgI5qP53Cf6eoZyO1Fwg==", "fcca7553-5e81-46ef-98bc-3425481c67e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eed25b4-3ad4-41d7-98da-142c41ebb7a0", "AQAAAAIAAYagAAAAEGI1jPD0SFxLKJg4tmotdSTBlcya87071m8KiaUqYpuSjQLM7YJHvw1IQGS1l0Thgw==", "776573ad-1cf5-4079-8b64-ef48df83aba0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09053630-c6e5-43dd-a36e-efe00bdb436d", "AQAAAAIAAYagAAAAEFlrcxQNZARHssdB6oQ4kSu6jmEt1j6rGRKdPh9vdcDJW1loBB2JZjpknIFeQspSRQ==", "fba8106a-dd04-43a5-a61e-645e372d0c91" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 11, 46, 1, 231, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 11, 46, 1, 231, DateTimeKind.Local).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 11, 46, 1, 231, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 11, 46, 1, 231, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.AddForeignKey(
                name: "FK_gameplatforms_Games_GameId",
                table: "gameplatforms",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_gameplatforms_Platforms_PlatformId",
                table: "gameplatforms",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameplatforms_Games_GameId",
                table: "gameplatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_gameplatforms_Platforms_PlatformId",
                table: "gameplatforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gameplatforms",
                table: "gameplatforms");

            migrationBuilder.RenameTable(
                name: "gameplatforms",
                newName: "GamePlatform");

            migrationBuilder.RenameIndex(
                name: "IX_gameplatforms_PlatformId",
                table: "GamePlatform",
                newName: "IX_GamePlatform_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlatform",
                table: "GamePlatform",
                columns: new[] { "GameId", "PlatformId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de528eb4-d7ad-4561-b29f-e4ee04c0a72f", "AQAAAAIAAYagAAAAEFxGFRsKt24Zbpf1nHQVrbCQy5VBhGweiy0bA1ZjhmjB7pV/QdCXbnzhwJ7QR7apPg==", "17599c1c-2716-4feb-a118-366b13f742cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bc11f7c-27d0-45ff-ace8-8d3c03628702", "AQAAAAIAAYagAAAAEOAi4nYctaMBJlJuNaHDOF2gMAY3ahU3/0oZ22d6LDcvYuhF1uN1JxwhKBtLPL8ncA==", "ebb650cf-d381-4a9f-9c4f-d24316e665f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bb424b2-4372-4496-83e8-93a6aba6a016", "AQAAAAIAAYagAAAAEL0T7OUWHsFiSE3i6X79tNcI9nPaUb+PpVBgKpKEVHJncxYWQ9/ei14yFkUNBv7rmA==", "76009152-0562-4318-b0f6-a04aa7a025b1" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 22, 14, 42, 56, 590, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 22, 14, 42, 56, 590, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 22, 14, 42, 56, 590, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 22, 14, 42, 56, 590, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Games_GameId",
                table: "GamePlatform",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformId",
                table: "GamePlatform",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
