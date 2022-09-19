using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaDSoft63.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiendas_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documentos = table.Column<int>(type: "int", nullable: false),
                    Generos = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contrasenna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVinculación = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Administrador_TiendasId = table.Column<int>(type: "int", nullable: true),
                    FechaRegistroSistema = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TiendasId = table.Column<int>(type: "int", nullable: true),
                    ProductosId = table.Column<int>(type: "int", nullable: true),
                    FechaVinculaciónVendedor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientesId = table.Column<int>(type: "int", nullable: true),
                    Vendedor_ProductosId = table.Column<int>(type: "int", nullable: true),
                    TiendaDSoftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Productos_Vendedor_ProductosId",
                        column: x => x.Vendedor_ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Tiendas_Administrador_TiendasId",
                        column: x => x.Administrador_TiendasId,
                        principalTable: "Tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Tiendas_TiendaDSoftId",
                        column: x => x.TiendaDSoftId,
                        principalTable: "Tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Tiendas_TiendasId",
                        column: x => x.TiendasId,
                        principalTable: "Tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Administrador_TiendasId",
                table: "Personas",
                column: "Administrador_TiendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ClientesId",
                table: "Personas",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ProductosId",
                table: "Personas",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TiendaDSoftId",
                table: "Personas",
                column: "TiendaDSoftId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TiendasId",
                table: "Personas",
                column: "TiendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Vendedor_ProductosId",
                table: "Personas",
                column: "Vendedor_ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_ProductosId",
                table: "Tiendas",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
