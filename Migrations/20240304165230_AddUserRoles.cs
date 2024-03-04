using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<int>");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RoleId", "SecurityStamp", "UserName" },
                values: new object[] { "87f3c342-5d69-4d40-bda8-c8e2a2c20c45", "admin@rockstargames.com", "ADMIN@ROCKSTARGAMES.COM", "ADMIN@ROCKSTARGAMES.COM", "AQAAAAIAAYagAAAAEG1B34aDYvLUU7tEKUlLns2yDUsKteYOuM81r4NfxMNl94LM19vzJxyRil5UkhN6dg==", null, "c7273cab-5202-445e-aca4-7ac5efe45b4c", "admin@rockstargames.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RoleId", "SecurityStamp", "UserName" },
                values: new object[] { "0dfca3a7-34ad-49d7-b422-63c4a7572fbb", "and.rea@rockstargames.com", "AND.REA@ROCKSTARGAMES.COM", "AND.REA@ROCKSTARGAMES.COM", "AQAAAAIAAYagAAAAEOr4d3fTVmnsALgCbQpLMVjn0w0sBSyp0k/rjSXYv5mQDPDSxP7Kcwfx/zROCMolQA==", null, "a144c0b2-f0a5-43d7-98d0-5397a1622b97", "and.rea@rockstargames.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RoleId", "SecurityStamp", "UserName" },
                values: new object[] { "eed13eda-da9f-4671-b49b-91037057139b", "john.smith@ubisoft.com", "JOHN.SMITH@UBISOFT.COM", "JOHN.SMITH@UBISOFT.COM", "AQAAAAIAAYagAAAAEF5knrQMsflLEpb9QVfqWsLPlQRicjWoN6vdlaGm3Mc4l8fzwRmqNfL0L407+c+rRA==", null, "52c4a5f1-28bf-463f-910b-a341c0363144", "john.smith@ubisoft.com" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "IdentityRole<int>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<int>", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "39d6a80e-bef9-4cbb-8c9d-5e94a69fef07", "admin@admin.com", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEP7dzuCTQ8gzODCQjSBRHTjZiklWAUCkmh5t0t3sLZkxTDArY0otc6NahbGGq93CUw==", null, "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "84bdfcd0-d8ea-4942-af7c-cca9ccbd6ae1", "and.rea@test.com", "AND.REA@TEST.COM", "AND_REA", "AQAAAAIAAYagAAAAEMIinxXBhIoRY32VGHJPwpXpBQ7+QxReqQxBls+hSuZl9ASdMr9PGi2hSBSnK8Jo4g==", null, "and_rea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "177d97fa-1a05-40cf-ae34-60b56db51778", "john.smith@test.com", "JOHN.SMITH@TEST.COM", "JOHNSMITH15", "AQAAAAIAAYagAAAAEPWRWy1mj9iGySKvvmY2VmfmOuHiKnVgCbSnA3nxhgY6YB1KhldsHQsjI0PlQVh0MQ==", null, "johnSmith15" });

            migrationBuilder.InsertData(
                table: "IdentityRole<int>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 12, 15, 1, 622, DateTimeKind.Local).AddTicks(3153));
        }
    }
}
