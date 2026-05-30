using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_VR_Peliculas.Migrations
{
    /// <inheritdoc />
    public partial class AgregarImagenAPeliculas : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Agregamos la columna primero (esto ya lo hace tu migración)
            migrationBuilder.AddColumn<string>(
                name: "ImagenNombre",
                table: "Peliculas",
                type: "nvarchar(max)",
                nullable: true);

            // 2. EJECUTAMOS SQL PURO: Borramos los duplicados (IDs del 6 al 10) 
            // y actualizamos los registros originales (1 al 5)
            migrationBuilder.Sql(@"
        UPDATE Peliculas SET ImagenNombre = 'avengers_endgame.png' WHERE Nombre LIKE '%Avengers%';
        UPDATE Peliculas SET ImagenNombre = 'inception.png' WHERE Nombre LIKE '%Inception%';
        UPDATE Peliculas SET ImagenNombre = 'avatar.png' WHERE Nombre LIKE '%Avatar%';
        UPDATE Peliculas SET ImagenNombre = 'jurassic_park.png' WHERE Nombre LIKE '%Jurassic%';
        UPDATE Peliculas SET ImagenNombre = 'parasite.png' WHERE Nombre LIKE '%Parasite%';
    ");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenNombre",
                table: "Peliculas");
        }
    }
}
