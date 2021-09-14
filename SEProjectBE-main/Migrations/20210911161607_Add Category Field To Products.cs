using Microsoft.EntityFrameworkCore.Migrations;

namespace SEProjectBE.Migrations
{
    public partial class AddCategoryFieldToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Products");
        }
    }
}
