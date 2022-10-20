using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektApp.Migrations
{
    public partial class AuctionDb_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 5, 31, 41, 460, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "BidDate", "OfferAmount" },
                values: new object[] { new DateTime(2022, 10, 20, 5, 31, 41, 460, DateTimeKind.Local).AddTicks(7912), 140 });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 20, 5, 31, 41, 460, DateTimeKind.Local).AddTicks(7908));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 4, 12, 11, 982, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "BidDate", "OfferAmount" },
                values: new object[] { new DateTime(2022, 10, 20, 4, 12, 11, 982, DateTimeKind.Local).AddTicks(1700), 120 });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidDate",
                value: new DateTime(2022, 10, 20, 4, 12, 11, 982, DateTimeKind.Local).AddTicks(1696));
        }
    }
}
