using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class patchequipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_CategoriaEquipos_CategoriaEquipoId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_CategoriaEquipoId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "CategoriaEquipoId",
                table: "Equipos");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_IdCategoriaEquipo",
                table: "Equipos",
                column: "IdCategoriaEquipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_CategoriaEquipos_IdCategoriaEquipo",
                table: "Equipos",
                column: "IdCategoriaEquipo",
                principalTable: "CategoriaEquipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_CategoriaEquipos_IdCategoriaEquipo",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_IdCategoriaEquipo",
                table: "Equipos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaEquipoId",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CategoriaEquipoId",
                table: "Equipos",
                column: "CategoriaEquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_CategoriaEquipos_CategoriaEquipoId",
                table: "Equipos",
                column: "CategoriaEquipoId",
                principalTable: "CategoriaEquipos",
                principalColumn: "Id");
        }
    }
}
