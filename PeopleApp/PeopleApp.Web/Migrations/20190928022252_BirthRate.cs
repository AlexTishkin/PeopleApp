using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleApp.Web.Migrations
{
    public partial class BirthRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthRates_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthRates_RegionId",
                table: "BirthRates",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthRates");
        }
    }
}
