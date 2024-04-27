using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITY.Migrations
{
    /// <inheritdoc />
    public partial class FirstModelER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    nombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    primerNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    segundoNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    primerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    segundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Celular = table.Column<long>(type: "bigint", nullable: false),
                    direccionResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudadResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paisResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.nombreUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    colorPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colorSecundario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colorTerciario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.idProducto);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    idFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direcionDeEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudadDeEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paisDeEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoEnvio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.idFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_nombreUsuario",
                        column: x => x.nombreUsuario,
                        principalTable: "Clientes",
                        principalColumn: "nombreUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    idFactura = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Facturas_idFactura",
                        column: x => x.idFactura,
                        principalTable: "Facturas",
                        principalColumn: "idFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_idProducto",
                        column: x => x.idProducto,
                        principalTable: "Productos",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tallas",
                columns: table => new
                {
                    idTalla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medida = table.Column<double>(type: "float", nullable: false),
                    idPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tallas", x => x.idTalla);
                    table.ForeignKey(
                        name: "FK_Tallas_Pedidos_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Pedidos",
                        principalColumn: "idPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_nombreUsuario",
                table: "Facturas",
                column: "nombreUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_idFactura",
                table: "Pedidos",
                column: "idFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_idProducto",
                table: "Pedidos",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Tallas_idPedido",
                table: "Tallas",
                column: "idPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tallas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
