using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleApp.Web.Migrations
{
    public partial class AddTableCensusPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CensusPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_CensusPlaces", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
