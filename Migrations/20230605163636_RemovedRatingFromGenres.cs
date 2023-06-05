using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmsystemet.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRatingFromGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PersonGenres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "PersonGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
