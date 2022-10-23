using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektApp.Migrations
{
    public partial class BidDb_changedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 23, 14, 51, 5, 620, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "BidDate",
                value: new DateTime(2022, 10, 23, 14, 51, 5, 620, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 23, 14, 51, 5, 620, DateTimeKind.Local).AddTicks(1379));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 23, 2, 8, 58, 648, DateTimeKind.Local).AddTicks(378));

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
    }
}
