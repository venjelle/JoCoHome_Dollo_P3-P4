using Microsoft.EntityFrameworkCore.Migrations;

namespace JoCoHome_Dollo.Data.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Land = table.Column<string>(nullable: true),
                    Provincie = table.Column<string>(nullable: true),
                    Plaats = table.Column<string>(nullable: true),
                    Aantalpersonen = table.Column<string>(nullable: true),
                    Slaapkamers = table.Column<string>(nullable: true),
                    Typehuisje = table.Column<string>(nullable: true),
                    Checkin = table.Column<string>(nullable: true),
                    Checkout = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
