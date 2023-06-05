using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmsystemet.Migrations
{
    /// <inheritdoc />
    public partial class UppdatedGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TMDBId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TMDBId",
                table: "Genres");
        }
    }
}
