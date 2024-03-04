using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class NumericIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "IdentityRole<int>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "39d6a80e-bef9-4cbb-8c9d-5e94a69fef07", "Admin", "Admin", "AQAAAAIAAYagAAAAEP7dzuCTQ8gzODCQjSBRHTjZiklWAUCkmh5t0t3sLZkxTDArY0otc6NahbGGq93CUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "84bdfcd0-d8ea-4942-af7c-cca9ccbd6ae1", "Andrea", "Test", "AQAAAAIAAYagAAAAEMIinxXBhIoRY32VGHJPwpXpBQ7+QxReqQxBls+hSuZl9ASdMr9PGi2hSBSnK8Jo4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "177d97fa-1a05-40cf-ae34-60b56db51778", "John", "Smith", "AQAAAAIAAYagAAAAEPWRWy1mj9iGySKvvmY2VmfmOuHiKnVgCbSnA3nxhgY6YB1KhldsHQsjI0PlQVh0MQ==" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerUserId",
                table: "Reviews",
                column: "ReviewerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerUserId",
                table: "Reviews",
                column: "ReviewerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerUserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "IdentityRole<int>");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ReviewerUserId",
                table: "Reviews");

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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "0c863a01-0111-43fb-a268-d1c7cdb73d14", null, null, "AQAAAAIAAYagAAAAEGLwmL0q2t3woyctEidpAX2xm8SHsFI9hnJLN3yYMu71TBG/LAYb21G8ohkrUgNp4Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "f536d13b-3608-4886-ad5f-cc757bb27e0e", null, null, "AQAAAAIAAYagAAAAEPsnyWnz/kocz0Vehg3fM8HBdNCxGLT6VSkia3OuP5Mwn7PG7u83YI3ghYrV48fmtg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "79f386fe-6b70-4c25-981d-217d5415224c", null, null, "AQAAAAIAAYagAAAAEAXlU3IWQoA1KmDV1e/BpV5im5A1rSFoMcS5WtSIMRB+SXFOqXBc+4QSowCS2aCxrw==" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 1, 15, 26, 0, 8, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 1, 15, 26, 0, 8, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 1, 15, 26, 0, 8, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 1, 15, 26, 0, 8, DateTimeKind.Local).AddTicks(7850));
        }
    }
}
