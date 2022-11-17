using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaArabeApi.Migrations
{
    public partial class AlunosModalidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_Alunos_modalidadeId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "aulaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "modalidadeId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "Alunos",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_enderecoId",
                table: "Alunos",
                newName: "IX_Alunos_EnderecoId");

            migrationBuilder.CreateTable(
                name: "AlunoModalidades",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoModalidades", x => new { x.AlunoId, x.ModalidadeId });
                    table.ForeignKey(
                        name: "FK_AlunoModalidades_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoModalidades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoModalidades_ModalidadeId",
                table: "AlunoModalidades",
                column: "ModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "AlunoModalidades");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Alunos",
                newName: "enderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                newName: "IX_Alunos_enderecoId");

            migrationBuilder.AddColumn<int>(
                name: "aulaId",
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
    }
}
