using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektApp.Migrations
{
    public partial class AuctionDbs_AddedImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AuctionDbs",
                newName: "AuctionOwner");

            migrationBuilder.AddColumn<float>(
                name: "HighestBid",
                table: "AuctionDbs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AuctionDbs",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "HighestBid", "ImageUrl" },
                values: new object[] { new DateTime(2022, 10, 23, 2, 8, 58, 648, DateTimeKind.Local).AddTicks(378), 100f, "https://tinyjpg.com/images/social/website.jpg" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "BidDate",
                value: new DateTime(2022, 10, 23, 2, 8, 58, 648, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 23, 2, 8, 58, 648, DateTimeKind.Local).AddTicks(541));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "AuctionDbs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AuctionDbs");

            migrationBuilder.RenameColumn(
                name: "AuctionOwner",
                table: "AuctionDbs",
                newName: "UserName");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 21, 22, 22, 41, 888, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "BidDate",
                value: new DateTime(2022, 10, 21, 22, 22, 41, 888, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 21, 22, 22, 41, 888, DateTimeKind.Local).AddTicks(2919));
        }
    }
}
