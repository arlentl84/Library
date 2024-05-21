using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.WebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_concurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Usuarios",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Suscripciones",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Revisiones",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Libros",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Autores",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Suscripciones");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Revisiones");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Autores");
        }
    }
}
