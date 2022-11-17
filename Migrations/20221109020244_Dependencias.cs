using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaArabeApi.Migrations
{
    public partial class Dependencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "aulaId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "enderecoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "modalidadeId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_aulaId",
                table: "Alunos",
                column: "aulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_enderecoId",
                table: "Alunos",
                column: "enderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_modalidadeId",
                table: "Alunos",
                column: "modalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Aulas_aulaId",
                table: "Alunos",
                column: "aulaId",
                principalTable: "Aulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Enderecos_enderecoId",
                table: "Alunos",
                column: "enderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Modalidades_modalidadeId",
                table: "Alunos",
                column: "modalidadeId",
                principalTable: "Modalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Aulas_aulaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Enderecos_enderecoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Modalidades_modalidadeId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_aulaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_enderecoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_modalidadeId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "aulaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "enderecoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "modalidadeId",
                table: "Alunos");
        }
    }
}
