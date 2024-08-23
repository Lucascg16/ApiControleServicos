using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControleServicos.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoTabelaServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "servico",
                newName: "DataFinalizado");

            migrationBuilder.AlterColumn<bool>(
                name: "Excluido",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Usuario",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "Usuario",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<bool>(
                name: "Excluido",
                table: "servico",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCriacao",
                table: "servico",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "servico",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<bool>(
                name: "Excluido",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Empresa",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "Empresa",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .OldAnnotation("Relational:ColumnOrder", 102);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataFinalizado",
                table: "servico",
                newName: "DataInicio");

            migrationBuilder.AlterColumn<bool>(
                name: "Excluido",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Usuario",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "Usuario",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<bool>(
                name: "Excluido",
                table: "servico",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCriacao",
                table: "servico",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "servico",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<bool>(
                name: "Excluido",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Empresa",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "Empresa",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "dateTime")
                .Annotation("Relational:ColumnOrder", 102);
        }
    }
}
