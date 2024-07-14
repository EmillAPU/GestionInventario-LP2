using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionInventario.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Almacen__3213E83F3BAEA390", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3213E83FE17FBEF7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    contacto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__3213E83FA1CD6826", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    id_proveedor = table.Column<int>(type: "int", nullable: true),
                    id_categoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__3213E83F4BC45669", x => x.id);
                    table.ForeignKey(
                        name: "FK__Producto__id_cat__412EB0B6",
                        column: x => x.id_categoria,
                        principalTable: "Categoria",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Producto__id_pro__403A8C7D",
                        column: x => x.id_proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Ajuste",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    id_almacen = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    motivo = table.Column<string>(type: "text", nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ajuste__3213E83F391B0EE8", x => x.id);
                    table.ForeignKey(
                        name: "FK__Ajuste__id_almac__4E88ABD4",
                        column: x => x.id_almacen,
                        principalTable: "Almacen",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Ajuste__id_produ__4D94879B",
                        column: x => x.id_producto,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    id_almacen = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entrada__3213E83F3D86FD45", x => x.id);
                    table.ForeignKey(
                        name: "FK__Entrada__id_alma__46E78A0C",
                        column: x => x.id_almacen,
                        principalTable: "Almacen",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Entrada__id_prod__45F365D3",
                        column: x => x.id_producto,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    id_almacen = table.Column<int>(type: "int", nullable: true),
                    cantidad_actual = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__3213E83F6FF81F6D", x => x.id);
                    table.ForeignKey(
                        name: "FK__Inventari__id_al__52593CB8",
                        column: x => x.id_almacen,
                        principalTable: "Almacen",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Inventari__id_pr__5165187F",
                        column: x => x.id_producto,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Salida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    id_almacen = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Salida__3213E83FBC425886", x => x.id);
                    table.ForeignKey(
                        name: "FK__Salida__id_almac__4AB81AF0",
                        column: x => x.id_almacen,
                        principalTable: "Almacen",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Salida__id_produ__49C3F6B7",
                        column: x => x.id_producto,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ajuste_id_almacen",
                table: "Ajuste",
                column: "id_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_Ajuste_id_producto",
                table: "Ajuste",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_id_almacen",
                table: "Entrada",
                column: "id_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_id_producto",
                table: "Entrada",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_id_almacen",
                table: "Inventario",
                column: "id_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_id_producto",
                table: "Inventario",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_id_categoria",
                table: "Producto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_id_proveedor",
                table: "Producto",
                column: "id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_id_almacen",
                table: "Salida",
                column: "id_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_Salida_id_producto",
                table: "Salida",
                column: "id_producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajuste");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Salida");

            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
