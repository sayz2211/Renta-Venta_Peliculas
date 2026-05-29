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
                name: "Clientes", table: "Ventas", type: "int", nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clientes", table: "Rentas", type: "int", nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Clientes", table: "Ventas", column: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_Clientes", table: "Rentas", column: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentas_Clientes_Clientes", table: "Rentas",
                column: "Clientes", principalTable: "Clientes", principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_Clientes", table: "Ventas",
                column: "Clientes", principalTable: "Clientes", principalColumn: "Id");

            // Actualizar registros existentes
            migrationBuilder.Sql("UPDATE Ventas SET Clientes = 1 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Ventas SET Clientes = 2 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Ventas SET Clientes = 3 WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Ventas SET Clientes = 4 WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Ventas SET Clientes = 5 WHERE Id = 5");

            migrationBuilder.Sql("UPDATE Rentas SET Clientes = 1 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Rentas SET Clientes = 2 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Rentas SET Clientes = 3 WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Rentas SET Clientes = 4 WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Rentas SET Clientes = 5 WHERE Id = 5");
        }
    }
}