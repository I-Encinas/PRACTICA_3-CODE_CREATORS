using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRACTICA3.Migrations
{
    public partial class Migacion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //CREACION TABLA CLIENTE

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CI = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });
            //CREACION TABLA PRODUCTO

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioU = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                });
            //CREACION TABLA VENTAS

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioTotal = table.Column<double>(type: "float", nullable: false)
                },
                //ASIGNACION DE LLAVES FORANEAS

                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });
            //CREACION DE TABLA INTERSECCION ENTRE VENTAS Y PRODUCTOS

            migrationBuilder.CreateTable(
                name: "VENTAS_P",
                columns: table => new
                {
                    ProductosProductoID = table.Column<int>(type: "int", nullable: false),
                    VentasVentaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENTAS_P", x => new { x.ProductosProductoID, x.VentasVentaID });
                    table.ForeignKey(
                        name: "FK_VENTAS_P_Producto_ProductosProductoID",
                        column: x => x.ProductosProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENTAS_P_Venta_VentasVentaID",
                        column: x => x.VentasVentaID,
                        principalTable: "Venta",
                        principalColumn: "VentaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteID",
                table: "Venta",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_P_VentasVentaID",
                table: "VENTAS_P",
                column: "VentasVentaID");
        }
        //ELIMINA LOS CAMBIOS EN LA BD Y ELIMINA LAS TABLAS 

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VENTAS_P");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
