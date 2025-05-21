using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookaBook.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpruntFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "etat",
                table: "Emprunts",
                newName: "Etat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Etat",
                table: "Emprunts",
                newName: "etat");
        }
    }
}
