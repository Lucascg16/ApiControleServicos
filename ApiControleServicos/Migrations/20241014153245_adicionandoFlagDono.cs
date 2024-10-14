using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoFlagDono : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dono",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dono",
                table: "Usuario");
        }
    }
}
