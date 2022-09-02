using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleMVC.Migrations
{
    public partial class correctedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_procuts",
                table: "procuts");

            migrationBuilder.RenameTable(
                name: "procuts",
                newName: "products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "procuts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_procuts",
                table: "procuts",
                column: "Id");
        }
    }
}
