using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class LibraryManagementDB2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Branches",
                newName: "BranchName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "Branches",
                newName: "Name");
        }
    }
}
