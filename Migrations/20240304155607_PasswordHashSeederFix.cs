using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class PasswordHashSeederFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4da44d99-2d9f-4a73-95a0-d7778f3257e2", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDOh5TfuVpe0xArHEV5qUKUa3QVz/MD7BUTVMgZuYUYxPjAEsfJ26ThRplfi92OTAQ==", "eec623b1-8272-4043-856a-b5878d5a8d56", "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8cf8b60d-1e0a-4def-bcd8-92b1a15055e1", "AND.REA@TEST.COM", "AQAAAAIAAYagAAAAEG02ag5/X1k0Qa4evCOWnoyo2KLG9Ct6wfQdgsLvp1+5JMuoaUaFUILzXTxCT63Z5w==", "eaa37acd-4c97-4da0-94e4-cf2c1fd50f32", "and.rea@test.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9618e573-4ffc-4415-b553-66b8beb08992", "JOHN.SMITH@TEST.COM", "AQAAAAIAAYagAAAAEMWzUaBb45lhRWV/9iZ8dwXToy6eBznCY+5oHDqFutS1hqNReERfaAf8Ci2WfNizqw==", "613bc5b8-3f44-4be6-bcf5-eb1a21626924", "john.smith@test.com" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 56, 7, 489, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 56, 7, 489, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 56, 7, 489, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 56, 7, 489, DateTimeKind.Local).AddTicks(184));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "fec4122c-5810-41a6-aff2-9fbc07a07976", "ADMIN", "AQAAAAIAAYagAAAAENHEJlUCATO+s1hBYfhztXWR4Z13PD3P4vId76kLBmdGOBXzc8A1FUTS9jN5uO+jFg==", "b8aa3fea-7bd7-4e9f-bb8d-989eaea3f9eb", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f9e6e6df-adc6-4207-ac7e-3988aa75784b", "AND_REA", "AQAAAAIAAYagAAAAEBnc+qTi1dta2OzmgZqdv58NtTTcI7DWsLmCJRIxU9Yvw5xdQM3R30VB/Z3VuVXUaA==", "ccd8000e-72e5-4599-85d9-5ba8c13c7296", "and_rea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f1a4734f-1aa4-474c-95ca-b6082279fd90", "JOHNSMITH15", "AQAAAAIAAYagAAAAEGrQWgbk9knClpttU7S0O63t1Tr+XzZ1FAZLfl0Z71ZFNpG/NZZyTpOWRJfZl9+1+A==", "aa34ee55-3638-4862-a4eb-46699b2bcd9f", "johnSmith15" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 49, 32, 53, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 49, 32, 53, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 49, 32, 53, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 16, 49, 32, 53, DateTimeKind.Local).AddTicks(5752));
        }
    }
}
