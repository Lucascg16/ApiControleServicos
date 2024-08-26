using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class addMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DataDeCriacao = table.Column<DateTime>(type: "dateTime", nullable: false),
                    DataDeAtualizacao = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DataDeCriacao = table.Column<DateTime>(type: "dateTime", nullable: false),
                    DataDeAtualizacao = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(Max)", nullable: true),
                    Custos = table.Column<double>(type: "float", nullable: true),
                    OrcamentoInicial = table.Column<double>(type: "float", nullable: true),
                    ValorFaturado = table.Column<double>(type: "float", nullable: true),
                    LucroLiquido = table.Column<double>(type: "float", nullable: true),
                    DataFinalizado = table.Column<DateTime>(type: "dateTime", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DataDeCriacao = table.Column<DateTime>(type: "dateTime", nullable: false),
                    DataDeAtualizacao = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servico_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_servico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_servico_EmpresaId",
                table: "servico",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_servico_UsuarioId",
                table: "servico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
