using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProveedoresApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreComercial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentificacionTributaria = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Facturacion = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    UltimaEdicion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_IdentificacionTributaria",
                table: "Proveedores",
                column: "IdentificacionTributaria",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
