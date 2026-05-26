using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria_VR_Peliculas.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre_Artistico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitulada = table.Column<bool>(type: "bit", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuracionDias = table.Column<int>(type: "int", nullable: false),
                    RentasPermitidas = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio_Dia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Fecha_Renta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Limite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio_Venta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clasi_edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    Directores = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peliculas_Directores_Directores",
                        column: x => x.Directores,
                        principalTable: "Directores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_Roles",
                        column: x => x.Roles,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Membresias = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Membresias_Membresias",
                        column: x => x.Membresias,
                        principalTable: "Membresias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clientes_Status_Status",
                        column: x => x.Status,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Sucursales = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Status_Status",
                        column: x => x.Status,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empleados_Sucursales_Sucursales",
                        column: x => x.Sucursales,
                        principalTable: "Sucursales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Peliculas = table.Column<int>(type: "int", nullable: true),
                    Formatos = table.Column<int>(type: "int", nullable: true),
                    Sucursales = table.Column<int>(type: "int", nullable: true),
                    Proveedores = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventarios_Formatos_Formatos",
                        column: x => x.Formatos,
                        principalTable: "Formatos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventarios_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventarios_Proveedores_Proveedores",
                        column: x => x.Proveedores,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventarios_Sucursales_Sucursales",
                        column: x => x.Sucursales,
                        principalTable: "Sucursales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Repartos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actores = table.Column<int>(type: "int", nullable: true),
                    Peliculas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repartos_Actores_Actores",
                        column: x => x.Actores,
                        principalTable: "Actores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repartos_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TiposGeneros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peliculas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGeneros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposGeneros_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tabla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatosAnteriores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatosNuevos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuarios = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuarios_Usuarios",
                        column: x => x.Usuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Clientes = table.Column<int>(type: "int", nullable: true),
                    Rentas = table.Column<int>(type: "int", nullable: true),
                    Ventas = table.Column<int>(type: "int", nullable: true),
                    Descuentos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_Clientes",
                        column: x => x.Clientes,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturas_Descuentos_Descuentos",
                        column: x => x.Descuentos,
                        principalTable: "Descuentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturas_Rentas_Rentas",
                        column: x => x.Rentas,
                        principalTable: "Rentas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturas_Ventas_Ventas",
                        column: x => x.Ventas,
                        principalTable: "Ventas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Formatos_Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio_Formato = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peliculas = table.Column<int>(type: "int", nullable: true),
                    Formatos = table.Column<int>(type: "int", nullable: true),
                    Inventarios = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formatos_Peliculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formatos_Peliculas_Formatos_Formatos",
                        column: x => x.Formatos,
                        principalTable: "Formatos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formatos_Peliculas_Inventarios_Inventarios",
                        column: x => x.Inventarios,
                        principalTable: "Inventarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formatos_Peliculas_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Devoluciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Multa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio_Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Clientes = table.Column<int>(type: "int", nullable: true),
                    Peliculas = table.Column<int>(type: "int", nullable: true),
                    Facturas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devoluciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devoluciones_Clientes_Clientes",
                        column: x => x.Clientes,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Devoluciones_Facturas_Facturas",
                        column: x => x.Facturas,
                        principalTable: "Facturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Devoluciones_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reclamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Garantia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facturas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reclamos_Facturas_Facturas",
                        column: x => x.Facturas,
                        principalTable: "Facturas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rentas_Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    Precio_Dia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rentas = table.Column<int>(type: "int", nullable: true),
                    Peliculas = table.Column<int>(type: "int", nullable: true),
                    Formatos_Peliculas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentas_Peliculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentas_Peliculas_Formatos_Peliculas_Formatos_Peliculas",
                        column: x => x.Formatos_Peliculas,
                        principalTable: "Formatos_Peliculas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rentas_Peliculas_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rentas_Peliculas_Rentas_Rentas",
                        column: x => x.Rentas,
                        principalTable: "Rentas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ventas_Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio_U = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ventas = table.Column<int>(type: "int", nullable: true),
                    Peliculas = table.Column<int>(type: "int", nullable: true),
                    Formatos_Peliculas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas_Peliculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Peliculas_Formatos_Peliculas_Formatos_Peliculas",
                        column: x => x.Formatos_Peliculas,
                        principalTable: "Formatos_Peliculas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Peliculas_Peliculas_Peliculas",
                        column: x => x.Peliculas,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Peliculas_Ventas_Ventas",
                        column: x => x.Ventas,
                        principalTable: "Ventas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_Usuarios",
                table: "Auditorias",
                column: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Membresias",
                table: "Clientes",
                column: "Membresias");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Status",
                table: "Clientes",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_Clientes",
                table: "Devoluciones",
                column: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_Facturas",
                table: "Devoluciones",
                column: "Facturas");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_Peliculas",
                table: "Devoluciones",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Status",
                table: "Empleados",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Sucursales",
                table: "Empleados",
                column: "Sucursales");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Clientes",
                table: "Facturas",
                column: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Descuentos",
                table: "Facturas",
                column: "Descuentos");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Rentas",
                table: "Facturas",
                column: "Rentas");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Ventas",
                table: "Facturas",
                column: "Ventas");

            migrationBuilder.CreateIndex(
                name: "IX_Formatos_Peliculas_Formatos",
                table: "Formatos_Peliculas",
                column: "Formatos");

            migrationBuilder.CreateIndex(
                name: "IX_Formatos_Peliculas_Inventarios",
                table: "Formatos_Peliculas",
                column: "Inventarios");

            migrationBuilder.CreateIndex(
                name: "IX_Formatos_Peliculas_Peliculas",
                table: "Formatos_Peliculas",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_Formatos",
                table: "Inventarios",
                column: "Formatos");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_Peliculas",
                table: "Inventarios",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_Proveedores",
                table: "Inventarios",
                column: "Proveedores");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_Sucursales",
                table: "Inventarios",
                column: "Sucursales");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Directores",
                table: "Peliculas",
                column: "Directores");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_Facturas",
                table: "Reclamos",
                column: "Facturas");

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_Peliculas_Formatos_Peliculas",
                table: "Rentas_Peliculas",
                column: "Formatos_Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_Peliculas_Peliculas",
                table: "Rentas_Peliculas",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_Peliculas_Rentas",
                table: "Rentas_Peliculas",
                column: "Rentas");

            migrationBuilder.CreateIndex(
                name: "IX_Repartos_Actores",
                table: "Repartos",
                column: "Actores");

            migrationBuilder.CreateIndex(
                name: "IX_Repartos_Peliculas",
                table: "Repartos",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_TiposGeneros_Peliculas",
                table: "TiposGeneros",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Roles",
                table: "Usuarios",
                column: "Roles");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Peliculas_Formatos_Peliculas",
                table: "Ventas_Peliculas",
                column: "Formatos_Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Peliculas_Peliculas",
                table: "Ventas_Peliculas",
                column: "Peliculas");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Peliculas_Ventas",
                table: "Ventas_Peliculas",
                column: "Ventas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "Devoluciones");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Reclamos");

            migrationBuilder.DropTable(
                name: "Rentas_Peliculas");

            migrationBuilder.DropTable(
                name: "Repartos");

            migrationBuilder.DropTable(
                name: "TiposGeneros");

            migrationBuilder.DropTable(
                name: "Ventas_Peliculas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Formatos_Peliculas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Rentas");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Membresias");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Formatos");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Directores");
        }
    }
}
