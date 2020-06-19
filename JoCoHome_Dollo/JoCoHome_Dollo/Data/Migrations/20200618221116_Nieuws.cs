using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoCoHome_Dollo.Data.Migrations
{
    public partial class Nieuws : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nieuws",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: true),
                    Inleiding = table.Column<string>(nullable: true),
                    Schrijver = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Inhoud = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nieuws", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nieuws");
        }
    }
}
