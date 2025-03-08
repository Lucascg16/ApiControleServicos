using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class AlterarTipoFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Flag",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Ativo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Flag",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Ativo",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
