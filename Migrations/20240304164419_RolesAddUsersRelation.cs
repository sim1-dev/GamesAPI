using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class RolesAddUsersRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RoleId", "SecurityStamp", "UserName" },
                values: new object[] { "d2d345be-f029-41ad-927f-21796160578a", "admin@rockstargames.com", "ADMIN@ROCKSTARGAMES.COM", "ADMIN@ROCKSTARGAMES.COM", "AQAAAAIAAYagAAAAEM39mDHKvxPFl1xbBYV1b0cesH5UyBK3JiG1+812ziLW38PHXy2F2XDOIFdtaMiBxw==", null, "e82ff0bf-2207-471a-a14b-dbdf569fcb77", "admin@rockstargames.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RoleId", "SecurityStamp", "UserName" },
                values: new object[] { "bdbcfb5b-86bf-49a5-b770-5dc62a70fa58", "and.rea@rockstargames.com", "AND.REA@ROCKSTARGAMES.COM", "AND.REA@ROCKSTARGAMES.COM", "AQAAAAIAAYagAAAAENf6idEaiYolrVKLAe9jmvgB0byIUrFpOYDVDsYDG0hbQTck8B4h+J/7I8xdWBZHXQ==", null, "e7dc2bc5-433f-4345-856d-3ea07da06b59", "and.rea@rockstargames.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RoleId", "SecurityStamp", "UserName" },
                values: new object[] { "734547bc-3e3e-4a18-b38d-76da3a820a4a", "john.smith@ubisoft.com", "JOHN.SMITH@UBISOFT.COM", "JOHN.SMITH@UBISOFT.COM", "AQAAAAIAAYagAAAAEKONd5OvnFSL+nkQVtF54BnBYKp8PIJJxG3CfotxOVh9GXSsqrbXEM6KEi3TOdjq/Q==", null, "7ba4e7c2-285f-4436-8454-d06f8a1cee2b", "john.smith@ubisoft.com" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 44, 18, 873, DateTimeKind.Local).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 44, 18, 873, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 44, 18, 873, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 4, 17, 44, 18, 873, DateTimeKind.Local).AddTicks(2014));

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

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4da44d99-2d9f-4a73-95a0-d7778f3257e2", "admin@admin.com", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDOh5TfuVpe0xArHEV5qUKUa3QVz/MD7BUTVMgZuYUYxPjAEsfJ26ThRplfi92OTAQ==", "eec623b1-8272-4043-856a-b5878d5a8d56", "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8cf8b60d-1e0a-4def-bcd8-92b1a15055e1", "and.rea@test.com", "AND.REA@TEST.COM", "AND.REA@TEST.COM", "AQAAAAIAAYagAAAAEG02ag5/X1k0Qa4evCOWnoyo2KLG9Ct6wfQdgsLvp1+5JMuoaUaFUILzXTxCT63Z5w==", "eaa37acd-4c97-4da0-94e4-cf2c1fd50f32", "and.rea@test.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9618e573-4ffc-4415-b553-66b8beb08992", "john.smith@test.com", "JOHN.SMITH@TEST.COM", "JOHN.SMITH@TEST.COM", "AQAAAAIAAYagAAAAEMWzUaBb45lhRWV/9iZ8dwXToy6eBznCY+5oHDqFutS1hqNReERfaAf8Ci2WfNizqw==", "613bc5b8-3f44-4be6-bcf5-eb1a21626924", "john.smith@test.com" });

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
    }
}
