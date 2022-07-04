using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.data.Migrations
{
    public partial class PType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PType",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PType",
                table: "Products");
        }
    }
}
