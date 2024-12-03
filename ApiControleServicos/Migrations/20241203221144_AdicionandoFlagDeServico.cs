using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFlagDeServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_servico_Empresa_EmpresaId",
                table: "servico");

            migrationBuilder.DropForeignKey(
                name: "FK_servico_Usuario_UsuarioId",
                table: "servico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_servico",
                table: "servico");

            migrationBuilder.RenameTable(
                name: "servico",
                newName: "Servico");

            migrationBuilder.RenameIndex(
                name: "IX_servico_UsuarioId",
                table: "Servico",
                newName: "IX_Servico_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_servico_EmpresaId",
                table: "Servico",
                newName: "IX_Servico_EmpresaId");

            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Ativo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servico",
                table: "Servico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Empresa_EmpresaId",
                table: "Servico",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Usuario_UsuarioId",
                table: "Servico",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Empresa_EmpresaId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Usuario_UsuarioId",
                table: "Servico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servico",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Servico");

            migrationBuilder.RenameTable(
                name: "Servico",
                newName: "servico");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_UsuarioId",
                table: "servico",
                newName: "IX_servico_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Servico_EmpresaId",
                table: "servico",
                newName: "IX_servico_EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_servico",
                table: "servico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_servico_Empresa_EmpresaId",
                table: "servico",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_servico_Usuario_UsuarioId",
                table: "servico",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
