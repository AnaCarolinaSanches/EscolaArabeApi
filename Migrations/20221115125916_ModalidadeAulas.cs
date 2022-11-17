using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaArabeApi.Migrations
{
    public partial class ModalidadeAulas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAula",
                table: "Aulas");

            migrationBuilder.AddColumn<string>(
                name: "Dia",
                table: "Aulas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModalidadeAula",
                columns: table => new
                {
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadeAula", x => new { x.AulaId, x.ModalidadeId });
                    table.ForeignKey(
                        name: "FK_ModalidadeAula_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalidadeAula_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadeAula_ModalidadeId",
                table: "ModalidadeAula",
                column: "ModalidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModalidadeAula");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Aulas");

            migrationBuilder.AddColumn<DateTime>(
                name: "HorarioAula",
                table: "Aulas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
