using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGamePlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Games_GamesId",
                table: "GamePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformsId",
                table: "GamePlatform");

            migrationBuilder.RenameColumn(
                name: "PlatformsId",
                table: "GamePlatform",
                newName: "PlatformId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GamePlatform",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                newName: "IX_GamePlatform_PlatformId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Games_GameId",
                table: "GamePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformId",
                table: "GamePlatform");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "GamePlatform",
                newName: "PlatformsId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GamePlatform",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlatform_PlatformId",
                table: "GamePlatform",
                newName: "IX_GamePlatform_PlatformsId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87f3c342-5d69-4d40-bda8-c8e2a2c20c45", "AQAAAAIAAYagAAAAEG1B34aDYvLUU7tEKUlLns2yDUsKteYOuM81r4NfxMNl94LM19vzJxyRil5UkhN6dg==", "c7273cab-5202-445e-aca4-7ac5efe45b4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dfca3a7-34ad-49d7-b422-63c4a7572fbb", "AQAAAAIAAYagAAAAEOr4d3fTVmnsALgCbQpLMVjn0w0sBSyp0k/rjSXYv5mQDPDSxP7Kcwfx/zROCMolQA==", "a144c0b2-f0a5-43d7-98d0-5397a1622b97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eed13eda-da9f-4671-b49b-91037057139b", "AQAAAAIAAYagAAAAEF5knrQMsflLEpb9QVfqWsLPlQRicjWoN6vdlaGm3Mc4l8fzwRmqNfL0L407+c+rRA==", "52c4a5f1-28bf-463f-910b-a341c0363144" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 52, 30, 152, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 52, 30, 152, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 52, 30, 152, DateTimeKind.Local).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 52, 30, 152, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Games_GamesId",
                table: "GamePlatform",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Platforms_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
