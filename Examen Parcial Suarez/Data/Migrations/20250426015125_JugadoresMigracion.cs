using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial_.Data.Migrations
{
    /// <inheritdoc />
    public partial class JugadoresMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_equipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_asignamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipoId = table.Column<int>(type: "INTEGER", nullable: true),
                    JugadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_asignamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_asignamiento_t_equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "t_equipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_t_asignamiento_t_jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "t_jugadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_asignamiento_EquipoId",
                table: "t_asignamiento",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_asignamiento_JugadorId",
                table: "t_asignamiento",
                column: "JugadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_asignamiento");

            migrationBuilder.DropTable(
                name: "t_equipo");

            migrationBuilder.DropTable(
                name: "t_jugadores");
        }
    }
}
