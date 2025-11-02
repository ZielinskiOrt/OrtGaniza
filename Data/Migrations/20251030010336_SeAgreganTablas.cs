using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreganTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiembroProyecto_Usuario_UserId",
                table: "MiembroProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Proyectos_ProyectoId",
                table: "Tarea");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaColaborador_Tarea_TareaId",
                table: "TareaColaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaColaborador_Usuario_UserId",
                table: "TareaColaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaSolicitudBaja_Tarea_TareaId",
                table: "TareaSolicitudBaja");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaSolicitudBaja_Usuario_UserId",
                table: "TareaSolicitudBaja");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaTrace_Tarea_TareaId",
                table: "TareaTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaTrace_Usuario_UserId",
                table: "TareaTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_WebRoles_WebRoleId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarea",
                table: "Tarea");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Tarea",
                newName: "Tareas");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_WebRoleId",
                table: "Usuarios",
                newName: "IX_Usuarios_WebRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_ProyectoId",
                table: "Tareas",
                newName: "IX_Tareas_ProyectoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MiembroProyecto_Usuarios_UserId",
                table: "MiembroProyecto",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaColaborador_Tareas_TareaId",
                table: "TareaColaborador",
                column: "TareaId",
                principalTable: "Tareas",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaColaborador_Usuarios_UserId",
                table: "TareaColaborador",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Proyectos_ProyectoId",
                table: "Tareas",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "ProyectoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaSolicitudBaja_Tareas_TareaId",
                table: "TareaSolicitudBaja",
                column: "TareaId",
                principalTable: "Tareas",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaSolicitudBaja_Usuarios_UserId",
                table: "TareaSolicitudBaja",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaTrace_Tareas_TareaId",
                table: "TareaTrace",
                column: "TareaId",
                principalTable: "Tareas",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaTrace_Usuarios_UserId",
                table: "TareaTrace",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_WebRoles_WebRoleId",
                table: "Usuarios",
                column: "WebRoleId",
                principalTable: "WebRoles",
                principalColumn: "WebRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiembroProyecto_Usuarios_UserId",
                table: "MiembroProyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaColaborador_Tareas_TareaId",
                table: "TareaColaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaColaborador_Usuarios_UserId",
                table: "TareaColaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Proyectos_ProyectoId",
                table: "Tareas");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaSolicitudBaja_Tareas_TareaId",
                table: "TareaSolicitudBaja");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaSolicitudBaja_Usuarios_UserId",
                table: "TareaSolicitudBaja");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaTrace_Tareas_TareaId",
                table: "TareaTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_TareaTrace_Usuarios_UserId",
                table: "TareaTrace");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_WebRoles_WebRoleId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Tareas",
                newName: "Tarea");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_WebRoleId",
                table: "Usuario",
                newName: "IX_Usuario_WebRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tarea",
                newName: "IX_Tarea_ProyectoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarea",
                table: "Tarea",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MiembroProyecto_Usuario_UserId",
                table: "MiembroProyecto",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Proyectos_ProyectoId",
                table: "Tarea",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "ProyectoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaColaborador_Tarea_TareaId",
                table: "TareaColaborador",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaColaborador_Usuario_UserId",
                table: "TareaColaborador",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaSolicitudBaja_Tarea_TareaId",
                table: "TareaSolicitudBaja",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaSolicitudBaja_Usuario_UserId",
                table: "TareaSolicitudBaja",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaTrace_Tarea_TareaId",
                table: "TareaTrace",
                column: "TareaId",
                principalTable: "Tarea",
                principalColumn: "TareaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TareaTrace_Usuario_UserId",
                table: "TareaTrace",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_WebRoles_WebRoleId",
                table: "Usuario",
                column: "WebRoleId",
                principalTable: "WebRoles",
                principalColumn: "WebRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
