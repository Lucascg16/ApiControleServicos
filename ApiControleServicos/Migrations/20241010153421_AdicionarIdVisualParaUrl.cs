using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarIdVisualParaUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisualId",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisualId",
                table: "Usuario");
        }
    }
}
