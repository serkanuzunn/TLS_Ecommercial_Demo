using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLS_Ecomaercial_Demo_DataAccess.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockName",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Products",
                newName: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "StockName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "StockId");
        }
    }
}
