using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaCurrency.Infrastructure.Data.Migrations
{
    public partial class AddRateEntryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DollarToRubleRate = table.Column<decimal>(nullable: false),
                    EuroToRubleRate = table.Column<decimal>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateEntries");
        }
    }
}
