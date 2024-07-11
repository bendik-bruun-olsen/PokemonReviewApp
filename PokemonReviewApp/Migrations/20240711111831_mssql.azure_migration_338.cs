using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class mssqlazure_migration_338 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviwers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviwers",
                table: "Reviwers");

            migrationBuilder.RenameTable(
                name: "Reviwers",
                newName: "Reviewers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewers",
                table: "Reviewers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewers",
                table: "Reviewers");

            migrationBuilder.RenameTable(
                name: "Reviewers",
                newName: "Reviwers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviwers",
                table: "Reviwers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviwers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
