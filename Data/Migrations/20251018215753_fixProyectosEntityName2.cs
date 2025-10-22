using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fixProyectosEntityName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntidadesPrueba",
                table: "EntidadesPrueba");

            migrationBuilder.RenameTable(
                name: "EntidadesPrueba",
                newName: "Proyectos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proyectos",
                table: "Proyectos",
                column: "ProyectoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Proyectos",
                table: "Proyectos");

            migrationBuilder.RenameTable(
                name: "Proyectos",
                newName: "EntidadesPrueba");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntidadesPrueba",
                table: "EntidadesPrueba",
                column: "ProyectoId");
        }
    }
}
