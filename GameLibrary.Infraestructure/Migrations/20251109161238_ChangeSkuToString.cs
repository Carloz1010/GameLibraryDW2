using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLibrary.Infraestructure.Migrations
{
    public partial class ChangeSkuToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Elimina la clave primaria actual
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            // Elimina la columna SKU
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Games");

            // Crea la columna SKU como string (sin identity)
            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Vuelve a agregar la clave primaria
            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "SKU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "SKU",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "SKU");
        }
    }
}
