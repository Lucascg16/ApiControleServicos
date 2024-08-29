using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordERolesUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuario");
        }
    }
}
