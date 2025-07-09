using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRateAPI.Migrations
{
    /// <inheritdoc />
    public partial class MudandoEntidadeFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diretor",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "Elenco",
                table: "Filmes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diretor",
                table: "Filmes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Elenco",
                table: "Filmes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
