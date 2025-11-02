using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizaciontablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "WebRoles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proyectos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Proyectos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    EstimacionDias = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Vencida = table.Column<bool>(type: "bit", nullable: false),
                    Baja = table.Column<bool>(type: "bit", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WebRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Usuario_WebRoles_WebRoleId",
                        column: x => x.WebRoleId,
                        principalTable: "WebRoles",
                        principalColumn: "WebRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiembroProyecto",
                columns: table => new
                {
                    MiembroProyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baja = table.Column<bool>(type: "bit", nullable: false),
                    TipoRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiembroProyecto", x => x.MiembroProyectoId);
                    table.ForeignKey(
                        name: "FK_MiembroProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiembroProyecto_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TareaColaborador",
                columns: table => new
                {
                    TareaColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baja = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaColaborador", x => x.TareaColaboradorId);
                    table.ForeignKey(
                        name: "FK_TareaColaborador_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareaColaborador_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TareaSolicitudBaja",
                columns: table => new
                {
                    TareaSolicitudBajaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaSolicitudBaja", x => x.TareaSolicitudBajaId);
                    table.ForeignKey(
                        name: "FK_TareaSolicitudBaja_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareaSolicitudBaja_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TareaTrace",
                columns: table => new
                {
                    TareaTraceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoCambiado = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareaTrace", x => x.TareaTraceId);
                    table.ForeignKey(
                        name: "FK_TareaTrace_Tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tarea",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareaTrace_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiembroProyecto_ProyectoId",
                table: "MiembroProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_MiembroProyecto_UserId",
                table: "MiembroProyecto",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ProyectoId",
                table: "Tarea",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaColaborador_TareaId",
                table: "TareaColaborador",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaColaborador_UserId",
                table: "TareaColaborador",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaSolicitudBaja_TareaId",
                table: "TareaSolicitudBaja",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaSolicitudBaja_UserId",
                table: "TareaSolicitudBaja",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaTrace_TareaId",
                table: "TareaTrace",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_TareaTrace_UserId",
                table: "TareaTrace",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_WebRoleId",
                table: "Usuario",
                column: "WebRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiembroProyecto");

            migrationBuilder.DropTable(
                name: "TareaColaborador");

            migrationBuilder.DropTable(
                name: "TareaSolicitudBaja");

            migrationBuilder.DropTable(
                name: "TareaTrace");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "WebRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Proyectos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
