using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.data.Migrations
{
    public partial class prixxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prix",
                table: "Achats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prix",
                table: "Achats");
        }
    }
}
