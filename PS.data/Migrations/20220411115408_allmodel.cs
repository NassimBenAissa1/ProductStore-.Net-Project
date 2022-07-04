using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.data.Migrations
{
    public partial class allmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Myname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "myCategories",
                newName: "Myname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Myname",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Myname",
                table: "myCategories",
                newName: "Name");
        }
    }
}
