using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OwnerProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "PropertyOwner",
                newName: "ProfilePhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhotoId",
                table: "PropertyOwner",
                newName: "ProfilePictureId");
        }
    }
}
