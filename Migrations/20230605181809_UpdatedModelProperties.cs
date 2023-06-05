using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmsystemet.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Persons_PersonId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Genres_PersonId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "GenreMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId1",
                table: "GenreMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_GenreId1",
                table: "GenreMovies",
                column: "GenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_MovieId1",
                table: "GenreMovies",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovies_Genres_GenreId1",
                table: "GenreMovies",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovies_Movies_MovieId1",
                table: "GenreMovies",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovies_Genres_GenreId1",
                table: "GenreMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovies_Movies_MovieId1",
                table: "GenreMovies");

            migrationBuilder.DropIndex(
                name: "IX_GenreMovies_GenreId1",
                table: "GenreMovies");

            migrationBuilder.DropIndex(
                name: "IX_GenreMovies_MovieId1",
                table: "GenreMovies");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "GenreMovies");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "GenreMovies");

            migrationBuilder.AddColumn<int>(
                name: "GenreId1",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId1",
                table: "Movies",
                column: "GenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_PersonId",
                table: "Genres",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Persons_PersonId",
                table: "Genres",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId1",
                table: "Movies",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
