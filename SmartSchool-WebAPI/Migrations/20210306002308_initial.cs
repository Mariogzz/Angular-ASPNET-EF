using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alumnos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    apellido = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    matricula = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profesores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "materia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    profesorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materia", x => x.id);
                    table.ForeignKey(
                        name: "FK_materia_profesores_profesorId",
                        column: x => x.profesorId,
                        principalTable: "profesores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alumnoMateria",
                columns: table => new
                {
                    alumnoId = table.Column<int>(type: "int", nullable: false),
                    materiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnoMateria", x => new { x.alumnoId, x.materiaId });
                    table.ForeignKey(
                        name: "FK_alumnoMateria_alumnos_alumnoId",
                        column: x => x.alumnoId,
                        principalTable: "alumnos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumnoMateria_materia_materiaId",
                        column: x => x.materiaId,
                        principalTable: "materia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "alumnos",
                columns: new[] { "id", "apellido", "matricula", "nombre" },
                values: new object[,]
                {
                    { 1, "Kent", "33225555", "Marta" },
                    { 2, "Isabela", "3354288", "Paula" },
                    { 3, "Antonia", "55668899", "Laura" },
                    { 4, "Maria", "6565659", "Luiza" },
                    { 5, "Machado", "565685415", "Lucas" },
                    { 6, "Alvares", "456454545", "Pedro" },
                    { 7, "José", "9874512", "Paulo" }
                });

            migrationBuilder.InsertData(
                table: "profesores",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Lauro" },
                    { 2, "Roberto" },
                    { 3, "Ronaldo" },
                    { 4, "Rodrigo" },
                    { 5, "Alexandre" }
                });

            migrationBuilder.InsertData(
                table: "materia",
                columns: new[] { "id", "nombre", "profesorId" },
                values: new object[,]
                {
                    { 1, "Matemática", 1 },
                    { 2, "Física", 2 },
                    { 3, "Português", 3 },
                    { 4, "Inglês", 4 },
                    { 5, "Programação", 5 }
                });

            migrationBuilder.InsertData(
                table: "alumnoMateria",
                columns: new[] { "alumnoId", "materiaId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 5 },
                    { 2, 5 },
                    { 1, 5 },
                    { 7, 4 },
                    { 6, 4 },
                    { 5, 4 },
                    { 4, 4 },
                    { 1, 4 },
                    { 7, 3 },
                    { 5, 5 },
                    { 6, 3 },
                    { 7, 2 },
                    { 6, 2 },
                    { 3, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 7, 1 },
                    { 6, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 3, 3 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alumnoMateria_materiaId",
                table: "alumnoMateria",
                column: "materiaId");

            migrationBuilder.CreateIndex(
                name: "IX_materia_profesorId",
                table: "materia",
                column: "profesorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alumnoMateria");

            migrationBuilder.DropTable(
                name: "alumnos");

            migrationBuilder.DropTable(
                name: "materia");

            migrationBuilder.DropTable(
                name: "profesores");
        }
    }
}
