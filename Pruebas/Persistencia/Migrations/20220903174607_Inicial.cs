using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familiares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistroRethus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatronesCrecimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patron = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronesCrecimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SugerenciasCuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SugerenciasCuidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ninos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    Longitud = table.Column<float>(type: "real", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatronesCrecimientoId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ninos_PatronesCrecimientos_PatronesCrecimientoId",
                        column: x => x.PatronesCrecimientoId,
                        principalTable: "PatronesCrecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosHistoricos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatronesCrecimientoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosHistoricos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosHistoricos_PatronesCrecimientos_PatronesCrecimientoId",
                        column: x => x.PatronesCrecimientoId,
                        principalTable: "PatronesCrecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    FamiliarId = table.Column<int>(type: "int", nullable: true),
                    NinoId = table.Column<int>(type: "int", nullable: true),
                    SugerenciasCuidadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Familiares_FamiliarId",
                        column: x => x.FamiliarId,
                        principalTable: "Familiares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Ninos_NinoId",
                        column: x => x.NinoId,
                        principalTable: "Ninos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_SugerenciasCuidados_SugerenciasCuidadoId",
                        column: x => x.SugerenciasCuidadoId,
                        principalTable: "SugerenciasCuidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_FamiliarId",
                table: "HistoriasClinicas",
                column: "FamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_MedicoId",
                table: "HistoriasClinicas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_NinoId",
                table: "HistoriasClinicas",
                column: "NinoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_SugerenciasCuidadoId",
                table: "HistoriasClinicas",
                column: "SugerenciasCuidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninos_PatronesCrecimientoId",
                table: "Ninos",
                column: "PatronesCrecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosHistoricos_PatronesCrecimientoId",
                table: "RegistrosHistoricos",
                column: "PatronesCrecimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "RegistrosHistoricos");

            migrationBuilder.DropTable(
                name: "Familiares");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Ninos");

            migrationBuilder.DropTable(
                name: "SugerenciasCuidados");

            migrationBuilder.DropTable(
                name: "PatronesCrecimientos");
        }
    }
}
