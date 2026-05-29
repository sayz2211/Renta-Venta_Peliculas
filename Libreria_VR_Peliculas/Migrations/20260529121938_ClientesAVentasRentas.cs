using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_VR_Peliculas.Migrations
{
    /// <inheritdoc />
    public partial class ClientesAVentasRentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clientes",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clientes",
                table: "Rentas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Clientes",
                table: "Ventas",
                column: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_Clientes",
                table: "Rentas",
                column: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentas_Clientes_Clientes",
                table: "Rentas",
                column: "Clientes",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_Clientes",
                table: "Ventas",
                column: "Clientes",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentas_Clientes_Clientes",
                table: "Rentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_Clientes",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_Clientes",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Rentas_Clientes",
                table: "Rentas");

            migrationBuilder.DropColumn(
                name: "Clientes",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Clientes",
                table: "Rentas");
        }
    }
}
