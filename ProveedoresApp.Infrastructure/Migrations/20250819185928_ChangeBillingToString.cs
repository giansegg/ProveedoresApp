using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProveedoresApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBillingToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Facturacion",
                table: "Proveedores",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Facturacion",
                table: "Proveedores",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 20);
        }
    }
}
