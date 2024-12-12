using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStoredPhotoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoDescription",
                table: "StoredPhoto",
                newName: "PhotoPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "StoredPhoto",
                newName: "PhotoDescription");
        }
    }
}
