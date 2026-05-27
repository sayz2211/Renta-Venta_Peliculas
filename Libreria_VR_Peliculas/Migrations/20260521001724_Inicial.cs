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


            // ==================== STATUS ====================
            migrationBuilder.InsertData(table: "Status", columns: new[] { "Activo" }, values: new object[] { true });
            migrationBuilder.InsertData(table: "Status", columns: new[] { "Activo" }, values: new object[] { true });
            migrationBuilder.InsertData(table: "Status", columns: new[] { "Activo" }, values: new object[] { true });
            migrationBuilder.InsertData(table: "Status", columns: new[] { "Activo" }, values: new object[] { false });
            migrationBuilder.InsertData(table: "Status", columns: new[] { "Activo" }, values: new object[] { false });

            // ==================== ROLES ====================
            migrationBuilder.InsertData(table: "Roles", columns: new[] { "Nombre", "Descripcion", "Activo" }, values: new object[] { "Administrador", "Acceso total", true });
            migrationBuilder.InsertData(table: "Roles", columns: new[] { "Nombre", "Descripcion", "Activo" }, values: new object[] { "Empleado", "Acceso operativo", true });
            migrationBuilder.InsertData(table: "Roles", columns: new[] { "Nombre", "Descripcion", "Activo" }, values: new object[] { "Cliente", "Acceso básico", true });

            // ==================== MEMBRESIAS ====================
            migrationBuilder.InsertData(table: "Membresias", columns: new[] { "Tipo", "Precio", "DuracionDias", "RentasPermitidas", "Activo" }, values: new object[] { "Básica", 15000m, 30, 3, true });
            migrationBuilder.InsertData(table: "Membresias", columns: new[] { "Tipo", "Precio", "DuracionDias", "RentasPermitidas", "Activo" }, values: new object[] { "Premium", 35000m, 30, 10, true });
            migrationBuilder.InsertData(table: "Membresias", columns: new[] { "Tipo", "Precio", "DuracionDias", "RentasPermitidas", "Activo" }, values: new object[] { "VIP", 60000m, 30, 999, true });
            migrationBuilder.InsertData(table: "Membresias", columns: new[] { "Tipo", "Precio", "DuracionDias", "RentasPermitidas", "Activo" }, values: new object[] { "Anual", 150000m, 365, 999, true });
            migrationBuilder.InsertData(table: "Membresias", columns: new[] { "Tipo", "Precio", "DuracionDias", "RentasPermitidas", "Activo" }, values: new object[] { "Estudiantil", 10000m, 30, 5, false });

            // ==================== CLIENTES ====================
            migrationBuilder.InsertData(table: "Clientes", columns: new[] { "Nombre", "Cedula", "Correo", "Telefono", "Fecha", "Status", "Membresias" }, values: new object[] { "Santiago Gómez", "1028140229", "santiago@gmail.com", "3001234567", new DateTime(2024, 1, 15), 1, 1 });
            migrationBuilder.InsertData(table: "Clientes", columns: new[] { "Nombre", "Cedula", "Correo", "Telefono", "Fecha", "Status", "Membresias" }, values: new object[] { "Camila Vectori", "1000413610", "camila@gmail.com", "3109876543", new DateTime(2024, 2, 20), 1, 2 });
            migrationBuilder.InsertData(table: "Clientes", columns: new[] { "Nombre", "Cedula", "Correo", "Telefono", "Fecha", "Status", "Membresias" }, values: new object[] { "Andrés Martínez", "1014979387", "andres@gmail.com", "3152345678", new DateTime(2024, 3, 10), 1, 1 });
            migrationBuilder.InsertData(table: "Clientes", columns: new[] { "Nombre", "Cedula", "Correo", "Telefono", "Fecha", "Status", "Membresias" }, values: new object[] { "Laura Pérez", "1010155714", "laura@gmail.com", "3007654321", new DateTime(2024, 4, 5), 2, 3 });
            migrationBuilder.InsertData(table: "Clientes", columns: new[] { "Nombre", "Cedula", "Correo", "Telefono", "Fecha", "Status", "Membresias" }, values: new object[] { "Carlos Ríos", "1011395001", "carlos@gmail.com", "3123456789", new DateTime(2024, 5, 18), 2, 1 });

            // ==================== DIRECTORES ====================
            migrationBuilder.InsertData(table: "Directores", columns: new[] { "Nombre", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Anthony Russo", "Estadounidense", "MTV Movie Award", 12 });
            migrationBuilder.InsertData(table: "Directores", columns: new[] { "Nombre", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Christopher Nolan", "Británico", "Oscar, BAFTA", 11 });
            migrationBuilder.InsertData(table: "Directores", columns: new[] { "Nombre", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "James Cameron", "Canadiense", "Oscar, Globo de Oro", 8 });
            migrationBuilder.InsertData(table: "Directores", columns: new[] { "Nombre", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Steven Spielberg", "Estadounidense", "Oscar, DGA Award", 35 });
            migrationBuilder.InsertData(table: "Directores", columns: new[] { "Nombre", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Bong Joon-ho", "Surcoreano", "Oscar, Palma de Oro", 7 });

            // ==================== PELICULAS ====================
            migrationBuilder.InsertData(table: "Peliculas", columns: new[] { "Nombre", "Estreno", "Clasi_edad", "Puntuacion", "Disponibilidad", "Directores" }, values: new object[] { "Avengers: Endgame", "2019", "PG-13", 9, true, 1 });
            migrationBuilder.InsertData(table: "Peliculas", columns: new[] { "Nombre", "Estreno", "Clasi_edad", "Puntuacion", "Disponibilidad", "Directores" }, values: new object[] { "Inception", "2010", "PG-13", 10, true, 2 });
            migrationBuilder.InsertData(table: "Peliculas", columns: new[] { "Nombre", "Estreno", "Clasi_edad", "Puntuacion", "Disponibilidad", "Directores" }, values: new object[] { "Avatar", "2009", "PG-13", 8, false, 3 });
            migrationBuilder.InsertData(table: "Peliculas", columns: new[] { "Nombre", "Estreno", "Clasi_edad", "Puntuacion", "Disponibilidad", "Directores" }, values: new object[] { "Jurassic Park", "1993", "PG-13", 9, true, 4 });
            migrationBuilder.InsertData(table: "Peliculas", columns: new[] { "Nombre", "Estreno", "Clasi_edad", "Puntuacion", "Disponibilidad", "Directores" }, values: new object[] { "Parasite", "2019", "R", 10, true, 5 });

            // ==================== ACTORES ====================
            migrationBuilder.InsertData(table: "Actores", columns: new[] { "Nombre", "Nombre_Artistico", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Robert John Downey", "Robert Downey Jr.", "Estadounidense", "Globo de Oro", 50 });
            migrationBuilder.InsertData(table: "Actores", columns: new[] { "Nombre", "Nombre_Artistico", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Chris Hemsworth", "Chris Hemsworth", "Australiano", "MTV Movie Award", 30 });
            migrationBuilder.InsertData(table: "Actores", columns: new[] { "Nombre", "Nombre_Artistico", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Leonardo DiCaprio", "Leo DiCaprio", "Estadounidense", "Oscar, Globo de Oro", 40 });
            migrationBuilder.InsertData(table: "Actores", columns: new[] { "Nombre", "Nombre_Artistico", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Sam Neill", "Sam Neill", "Neozelandés", "BAFTA", 60 });
            migrationBuilder.InsertData(table: "Actores", columns: new[] { "Nombre", "Nombre_Artistico", "Nacionalidad", "Premios", "CantidadP" }, values: new object[] { "Song Kang-ho", "Song Kang-ho", "Surcoreano", "Cannes, Baeksang", 25 });

            // ==================== REPARTOS ====================
            migrationBuilder.InsertData(table: "Repartos", columns: new[] { "Personaje", "Rol", "Actores", "Peliculas" }, values: new object[] { "Tony Stark", "Principal", 1, 1 });
            migrationBuilder.InsertData(table: "Repartos", columns: new[] { "Personaje", "Rol", "Actores", "Peliculas" }, values: new object[] { "Thor Odinson", "Principal", 2, 1 });
            migrationBuilder.InsertData(table: "Repartos", columns: new[] { "Personaje", "Rol", "Actores", "Peliculas" }, values: new object[] { "Dom Cobb", "Principal", 3, 2 });
            migrationBuilder.InsertData(table: "Repartos", columns: new[] { "Personaje", "Rol", "Actores", "Peliculas" }, values: new object[] { "Dr. Alan Grant", "Principal", 4, 4 });
            migrationBuilder.InsertData(table: "Repartos", columns: new[] { "Personaje", "Rol", "Actores", "Peliculas" }, values: new object[] { "Ki-taek", "Principal", 5, 5 });

            // ==================== TIPOS GENEROS ====================
            migrationBuilder.InsertData(table: "TiposGeneros", columns: new[] { "Genero", "Peliculas" }, values: new object[] { "Acción", 1 });
            migrationBuilder.InsertData(table: "TiposGeneros", columns: new[] { "Genero", "Peliculas" }, values: new object[] { "Ciencia Ficción", 2 });
            migrationBuilder.InsertData(table: "TiposGeneros", columns: new[] { "Genero", "Peliculas" }, values: new object[] { "Drama", 3 });
            migrationBuilder.InsertData(table: "TiposGeneros", columns: new[] { "Genero", "Peliculas" }, values: new object[] { "Aventura", 4 });
            migrationBuilder.InsertData(table: "TiposGeneros", columns: new[] { "Genero", "Peliculas" }, values: new object[] { "Thriller", 5 });

            // ==================== SUCURSALES ====================
            migrationBuilder.InsertData(table: "Sucursales", columns: new[] { "Nombre", "Ciudad", "Direccion", "Telefono" }, values: new object[] { "CineRenta Centro", "Medellín", "Calle 50 #40-20", "6044561234" });
            migrationBuilder.InsertData(table: "Sucursales", columns: new[] { "Nombre", "Ciudad", "Direccion", "Telefono" }, values: new object[] { "CineRenta Sur", "Itagüí", "Cra 52 #10-15", "6044569876" });
            migrationBuilder.InsertData(table: "Sucursales", columns: new[] { "Nombre", "Ciudad", "Direccion", "Telefono" }, values: new object[] { "CineRenta Norte", "Bello", "Av. 33 #55-10", "6044563456" });
            migrationBuilder.InsertData(table: "Sucursales", columns: new[] { "Nombre", "Ciudad", "Direccion", "Telefono" }, values: new object[] { "CineRenta Bogotá", "Bogotá", "Calle 72 #11-35", "6017891234" });
            migrationBuilder.InsertData(table: "Sucursales", columns: new[] { "Nombre", "Ciudad", "Direccion", "Telefono" }, values: new object[] { "CineRenta Cali", "Cali", "Av. 6N #23-10", "6023456789" });

            // ==================== EMPLEADOS ====================
            migrationBuilder.InsertData(table: "Empleados", columns: new[] { "Nombre", "Ciudad", "Correo", "Telefono", "Cargo", "Status", "Sucursales" }, values: new object[] { "María López", "Medellín", "maria@cinerenta.com", "3001112233", "Cajero", 1, 1 });
            migrationBuilder.InsertData(table: "Empleados", columns: new[] { "Nombre", "Ciudad", "Correo", "Telefono", "Cargo", "Status", "Sucursales" }, values: new object[] { "Juan Torres", "Itagüí", "juan@cinerenta.com", "3112223344", "Supervisor", 1, 2 });
            migrationBuilder.InsertData(table: "Empleados", columns: new[] { "Nombre", "Ciudad", "Correo", "Telefono", "Cargo", "Status", "Sucursales" }, values: new object[] { "Paula Vélez", "Bello", "paula@cinerenta.com", "3153334455", "Cajero", 1, 3 });
            migrationBuilder.InsertData(table: "Empleados", columns: new[] { "Nombre", "Ciudad", "Correo", "Telefono", "Cargo", "Status", "Sucursales" }, values: new object[] { "Diego Mora", "Bogotá", "diego@cinerenta.com", "3004445566", "Gerente", 2, 4 });
            migrationBuilder.InsertData(table: "Empleados", columns: new[] { "Nombre", "Ciudad", "Correo", "Telefono", "Cargo", "Status", "Sucursales" }, values: new object[] { "Valentina Cruz", "Cali", "valentina@cinerenta.com", "3125556677", "Asesor", 1, 5 });

            // ==================== PROVEEDORES ====================
            migrationBuilder.InsertData(table: "Proveedores", columns: new[] { "Nombre", "Telefono", "Correo", "Ciudad" }, values: new object[] { "Distribuidora Warner", "6014561234", "warner@dist.com", "Bogotá" });
            migrationBuilder.InsertData(table: "Proveedores", columns: new[] { "Nombre", "Telefono", "Correo", "Ciudad" }, values: new object[] { "Sony Pictures Dist.", "6024569876", "sony@dist.com", "Cali" });
            migrationBuilder.InsertData(table: "Proveedores", columns: new[] { "Nombre", "Telefono", "Correo", "Ciudad" }, values: new object[] { "Universal Films CO", "6044563456", "universal@dist.com", "Medellín" });
            migrationBuilder.InsertData(table: "Proveedores", columns: new[] { "Nombre", "Telefono", "Correo", "Ciudad" }, values: new object[] { "Paramount Dist. SAS", "6057891234", "paramount@dist.com", "Barranquilla" });
            migrationBuilder.InsertData(table: "Proveedores", columns: new[] { "Nombre", "Telefono", "Correo", "Ciudad" }, values: new object[] { "Disney Latam Dist.", "6044567890", "disney@dist.com", "Medellín" });

            // ==================== FORMATOS ====================
            migrationBuilder.InsertData(table: "Formatos", columns: new[] { "Formato", "Idioma", "Subtitulada", "Disponible" }, values: new object[] { "DVD", "Español", false, true });
            migrationBuilder.InsertData(table: "Formatos", columns: new[] { "Formato", "Idioma", "Subtitulada", "Disponible" }, values: new object[] { "Blu-ray", "Inglés", true, true });
            migrationBuilder.InsertData(table: "Formatos", columns: new[] { "Formato", "Idioma", "Subtitulada", "Disponible" }, values: new object[] { "4K UHD", "Inglés", true, true });
            migrationBuilder.InsertData(table: "Formatos", columns: new[] { "Formato", "Idioma", "Subtitulada", "Disponible" }, values: new object[] { "DVD", "Inglés", true, false });
            migrationBuilder.InsertData(table: "Formatos", columns: new[] { "Formato", "Idioma", "Subtitulada", "Disponible" }, values: new object[] { "Blu-ray", "Español", false, true });

            // ==================== INVENTARIOS ====================
            migrationBuilder.InsertData(table: "Inventarios", columns: new[] { "Cantidad", "Peliculas", "Formatos", "Sucursales", "Proveedores" }, values: new object[] { 10, 1, 1, 1, 1 });
            migrationBuilder.InsertData(table: "Inventarios", columns: new[] { "Cantidad", "Peliculas", "Formatos", "Sucursales", "Proveedores" }, values: new object[] { 5, 2, 2, 2, 3 });
            migrationBuilder.InsertData(table: "Inventarios", columns: new[] { "Cantidad", "Peliculas", "Formatos", "Sucursales", "Proveedores" }, values: new object[] { 8, 3, 3, 1, 5 });
            migrationBuilder.InsertData(table: "Inventarios", columns: new[] { "Cantidad", "Peliculas", "Formatos", "Sucursales", "Proveedores" }, values: new object[] { 3, 4, 1, 3, 2 });
            migrationBuilder.InsertData(table: "Inventarios", columns: new[] { "Cantidad", "Peliculas", "Formatos", "Sucursales", "Proveedores" }, values: new object[] { 7, 5, 2, 4, 4 });

            // ==================== FORMATOS PELICULAS ====================
            migrationBuilder.InsertData(table: "Formatos_Peliculas", columns: new[] { "Precio_Formato", "Peliculas", "Formatos", "Inventarios" }, values: new object[] { 12000m, 1, 1, 1 });
            migrationBuilder.InsertData(table: "Formatos_Peliculas", columns: new[] { "Precio_Formato", "Peliculas", "Formatos", "Inventarios" }, values: new object[] { 18000m, 2, 2, 2 });
            migrationBuilder.InsertData(table: "Formatos_Peliculas", columns: new[] { "Precio_Formato", "Peliculas", "Formatos", "Inventarios" }, values: new object[] { 25000m, 3, 3, 3 });
            migrationBuilder.InsertData(table: "Formatos_Peliculas", columns: new[] { "Precio_Formato", "Peliculas", "Formatos", "Inventarios" }, values: new object[] { 10000m, 4, 1, 4 });
            migrationBuilder.InsertData(table: "Formatos_Peliculas", columns: new[] { "Precio_Formato", "Peliculas", "Formatos", "Inventarios" }, values: new object[] { 20000m, 5, 2, 5 });

            // ==================== DESCUENTOS ====================
            migrationBuilder.InsertData(table: "Descuentos", columns: new[] { "Descripcion", "Porcentaje", "Activo" }, values: new object[] { "Descuento estudiante", 10m, true });
            migrationBuilder.InsertData(table: "Descuentos", columns: new[] { "Descripcion", "Porcentaje", "Activo" }, values: new object[] { "Descuento adulto mayor", 15m, true });
            migrationBuilder.InsertData(table: "Descuentos", columns: new[] { "Descripcion", "Porcentaje", "Activo" }, values: new object[] { "Descuento temporada", 20m, true });
            migrationBuilder.InsertData(table: "Descuentos", columns: new[] { "Descripcion", "Porcentaje", "Activo" }, values: new object[] { "Descuento empleado", 25m, true });
            migrationBuilder.InsertData(table: "Descuentos", columns: new[] { "Descripcion", "Porcentaje", "Activo" }, values: new object[] { "Descuento fidelidad", 5m, false });

            // ==================== USUARIOS ====================
            migrationBuilder.InsertData(table: "Usuarios", columns: new[] { "NombreUsuario", "Correo", "Contrasena", "FechaRegistro", "Activo", "Roles" }, values: new object[] { "admin", "admin@cinerenta.com", "Admin123!", new DateTime(2024, 1, 1), true, 1 });
            migrationBuilder.InsertData(table: "Usuarios", columns: new[] { "NombreUsuario", "Correo", "Contrasena", "FechaRegistro", "Activo", "Roles" }, values: new object[] { "santiago", "santiago@gmail.com", "Pass123!", new DateTime(2024, 1, 15), true, 3 });
            migrationBuilder.InsertData(table: "Usuarios", columns: new[] { "NombreUsuario", "Correo", "Contrasena", "FechaRegistro", "Activo", "Roles" }, values: new object[] { "maria", "maria@cinerenta.com", "Pass123!", new DateTime(2024, 2, 1), true, 2 });
            migrationBuilder.InsertData(table: "Usuarios", columns: new[] { "NombreUsuario", "Correo", "Contrasena", "FechaRegistro", "Activo", "Roles" }, values: new object[] { "camila", "camila@gmail.com", "Pass123!", new DateTime(2024, 2, 20), true, 3 });
            migrationBuilder.InsertData(table: "Usuarios", columns: new[] { "NombreUsuario", "Correo", "Contrasena", "FechaRegistro", "Activo", "Roles" }, values: new object[] { "juan", "juan@cinerenta.com", "Pass123!", new DateTime(2024, 3, 1), false, 2 });

            // ==================== RENTAS ====================
            migrationBuilder.InsertData(table: "Rentas", columns: new[] { "Precio_Dia", "Cantidad", "Fecha_Renta", "Fecha_Limite" }, values: new object[] { 5000m, 1, new DateTime(2024, 6, 1), new DateTime(2024, 6, 5) });
            migrationBuilder.InsertData(table: "Rentas", columns: new[] { "Precio_Dia", "Cantidad", "Fecha_Renta", "Fecha_Limite" }, values: new object[] { 8000m, 2, new DateTime(2024, 6, 10), new DateTime(2024, 6, 14) });
            migrationBuilder.InsertData(table: "Rentas", columns: new[] { "Precio_Dia", "Cantidad", "Fecha_Renta", "Fecha_Limite" }, values: new object[] { 5000m, 1, new DateTime(2024, 7, 1), new DateTime(2024, 7, 4) });
            migrationBuilder.InsertData(table: "Rentas", columns: new[] { "Precio_Dia", "Cantidad", "Fecha_Renta", "Fecha_Limite" }, values: new object[] { 10000m, 3, new DateTime(2024, 7, 15), new DateTime(2024, 7, 19) });
            migrationBuilder.InsertData(table: "Rentas", columns: new[] { "Precio_Dia", "Cantidad", "Fecha_Renta", "Fecha_Limite" }, values: new object[] { 5000m, 1, new DateTime(2024, 8, 1), new DateTime(2024, 8, 5) });

            // ==================== RENTAS PELICULAS ====================
            migrationBuilder.InsertData(table: "Rentas_Peliculas", columns: new[] { "Cantidad", "Dias", "Precio_Dia", "Subtotal", "Rentas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 1, 4, 5000m, 20000m, 1, 1, 1 });
            migrationBuilder.InsertData(table: "Rentas_Peliculas", columns: new[] { "Cantidad", "Dias", "Precio_Dia", "Subtotal", "Rentas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 2, 4, 8000m, 64000m, 2, 2, 2 });
            migrationBuilder.InsertData(table: "Rentas_Peliculas", columns: new[] { "Cantidad", "Dias", "Precio_Dia", "Subtotal", "Rentas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 1, 3, 5000m, 15000m, 3, 3, 3 });
            migrationBuilder.InsertData(table: "Rentas_Peliculas", columns: new[] { "Cantidad", "Dias", "Precio_Dia", "Subtotal", "Rentas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 3, 4, 10000m, 120000m, 4, 4, 4 });
            migrationBuilder.InsertData(table: "Rentas_Peliculas", columns: new[] { "Cantidad", "Dias", "Precio_Dia", "Subtotal", "Rentas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 1, 4, 5000m, 20000m, 5, 5, 5 });

            // ==================== VENTAS ====================
            migrationBuilder.InsertData(table: "Ventas", columns: new[] { "Precio_Venta", "Cantidad" }, values: new object[] { 25000m, 1 });
            migrationBuilder.InsertData(table: "Ventas", columns: new[] { "Precio_Venta", "Cantidad" }, values: new object[] { 50000m, 2 });
            migrationBuilder.InsertData(table: "Ventas", columns: new[] { "Precio_Venta", "Cantidad" }, values: new object[] { 35000m, 1 });
            migrationBuilder.InsertData(table: "Ventas", columns: new[] { "Precio_Venta", "Cantidad" }, values: new object[] { 75000m, 3 });
            migrationBuilder.InsertData(table: "Ventas", columns: new[] { "Precio_Venta", "Cantidad" }, values: new object[] { 25000m, 1 });

            // ==================== VENTAS PELICULAS ====================
            migrationBuilder.InsertData(table: "Ventas_Peliculas", columns: new[] { "Cantidad", "Precio_U", "Subtotal", "Ventas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 1, 25000m, 25000m, 1, 1, 1 });
            migrationBuilder.InsertData(table: "Ventas_Peliculas", columns: new[] { "Cantidad", "Precio_U", "Subtotal", "Ventas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 2, 25000m, 50000m, 2, 2, 2 });
            migrationBuilder.InsertData(table: "Ventas_Peliculas", columns: new[] { "Cantidad", "Precio_U", "Subtotal", "Ventas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 1, 35000m, 35000m, 3, 3, 3 });
            migrationBuilder.InsertData(table: "Ventas_Peliculas", columns: new[] { "Cantidad", "Precio_U", "Subtotal", "Ventas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 3, 25000m, 75000m, 4, 4, 4 });
            migrationBuilder.InsertData(table: "Ventas_Peliculas", columns: new[] { "Cantidad", "Precio_U", "Subtotal", "Ventas", "Peliculas", "Formatos_Peliculas" }, values: new object[] { 1, 25000m, 25000m, 5, 5, 5 });

            // ==================== FACTURAS ====================
            migrationBuilder.InsertData(table: "Facturas", columns: new[] { "Codigo", "Fecha", "Total", "Clientes", "Rentas", "Ventas", "Descuentos" }, values: new object[] { "FAC-001", new DateTime(2024, 6, 1), 20000m, 1, 1, null, null });
            migrationBuilder.InsertData(table: "Facturas", columns: new[] { "Codigo", "Fecha", "Total", "Clientes", "Rentas", "Ventas", "Descuentos" }, values: new object[] { "FAC-002", new DateTime(2024, 6, 10), 25000m, 2, null, 1, null });
            migrationBuilder.InsertData(table: "Facturas", columns: new[] { "Codigo", "Fecha", "Total", "Clientes", "Rentas", "Ventas", "Descuentos" }, values: new object[] { "FAC-003", new DateTime(2024, 7, 1), 13500m, 3, 3, null, 1 });
            migrationBuilder.InsertData(table: "Facturas", columns: new[] { "Codigo", "Fecha", "Total", "Clientes", "Rentas", "Ventas", "Descuentos" }, values: new object[] { "FAC-004", new DateTime(2024, 7, 15), 115000m, 4, 4, 2, null });
            migrationBuilder.InsertData(table: "Facturas", columns: new[] { "Codigo", "Fecha", "Total", "Clientes", "Rentas", "Ventas", "Descuentos" }, values: new object[] { "FAC-005", new DateTime(2024, 8, 1), 20000m, 5, 5, null, null });

            // ==================== DEVOLUCIONES ====================
            migrationBuilder.InsertData(table: "Devoluciones", columns: new[] { "Fecha", "Multa", "Precio_Multa", "Clientes", "Peliculas", "Facturas" }, values: new object[] { new DateTime(2024, 6, 6), "Entrega tardía", 5000m, 1, 1, 1 });
            migrationBuilder.InsertData(table: "Devoluciones", columns: new[] { "Fecha", "Multa", "Precio_Multa", "Clientes", "Peliculas", "Facturas" }, values: new object[] { new DateTime(2024, 7, 5), "Sin multa", 0m, 3, 3, 3 });
            migrationBuilder.InsertData(table: "Devoluciones", columns: new[] { "Fecha", "Multa", "Precio_Multa", "Clientes", "Peliculas", "Facturas" }, values: new object[] { new DateTime(2024, 6, 15), "Disco rayado", 15000m, 2, 2, 2 });
            migrationBuilder.InsertData(table: "Devoluciones", columns: new[] { "Fecha", "Multa", "Precio_Multa", "Clientes", "Peliculas", "Facturas" }, values: new object[] { new DateTime(2024, 7, 20), "Entrega tardía", 5000m, 4, 4, 4 });
            migrationBuilder.InsertData(table: "Devoluciones", columns: new[] { "Fecha", "Multa", "Precio_Multa", "Clientes", "Peliculas", "Facturas" }, values: new object[] { new DateTime(2024, 8, 6), "Sin multa", 0m, 5, 5, 5 });

            // ==================== RECLAMOS ====================
            migrationBuilder.InsertData(table: "Reclamos", columns: new[] { "Motivo", "Fecha", "Garantia", "Facturas" }, values: new object[] { "Disco en mal estado", new DateTime(2024, 7, 2), "Cambio de disco", 3 });
            migrationBuilder.InsertData(table: "Reclamos", columns: new[] { "Motivo", "Fecha", "Garantia", "Facturas" }, values: new object[] { "Precio cobrado incorrecto", new DateTime(2024, 6, 2), "Devolución dinero", 1 });
            migrationBuilder.InsertData(table: "Reclamos", columns: new[] { "Motivo", "Fecha", "Garantia", "Facturas" }, values: new object[] { "Pelicula equivocada", new DateTime(2024, 7, 16), "Cambio de película", 4 });
            migrationBuilder.InsertData(table: "Reclamos", columns: new[] { "Motivo", "Fecha", "Garantia", "Facturas" }, values: new object[] { "Caja dañada", new DateTime(2024, 6, 11), "Sin garantía", 2 });
            migrationBuilder.InsertData(table: "Reclamos", columns: new[] { "Motivo", "Fecha", "Garantia", "Facturas" }, values: new object[] { "No reproduce en equipo", new DateTime(2024, 8, 2), "Cambio de disco", 5 });

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
