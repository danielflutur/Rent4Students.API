using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_StoredPhoto_ProfilePictureId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_University_StoredPhoto_ProfilePictureId",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_University_ProfilePictureId",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_Student_ProfilePictureId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "University",
                newName: "ProfilePhotoId");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "Student",
                newName: "ProfilePhotoId");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "Faculty",
                newName: "ProfilePhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_University_ProfilePhotoId",
                table: "University",
                column: "ProfilePhotoId",
                unique: true,
                filter: "[ProfilePhotoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProfilePhotoId",
                table: "Student",
                column: "ProfilePhotoId",
                unique: true,
                filter: "[ProfilePhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StoredPhoto_ProfilePhotoId",
                table: "Student",
                column: "ProfilePhotoId",
                principalTable: "StoredPhoto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_University_StoredPhoto_ProfilePhotoId",
                table: "University",
                column: "ProfilePhotoId",
                principalTable: "StoredPhoto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_StoredPhoto_ProfilePhotoId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_University_StoredPhoto_ProfilePhotoId",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_University_ProfilePhotoId",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_Student_ProfilePhotoId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoId",
                table: "University",
                newName: "ProfilePictureId");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoId",
                table: "Student",
                newName: "ProfilePictureId");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoId",
                table: "Faculty",
                newName: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_University_ProfilePictureId",
                table: "University",
                column: "ProfilePictureId",
                unique: true,
                filter: "[ProfilePictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProfilePictureId",
                table: "Student",
                column: "ProfilePictureId",
                unique: true,
                filter: "[ProfilePictureId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StoredPhoto_ProfilePictureId",
                table: "Student",
                column: "ProfilePictureId",
                principalTable: "StoredPhoto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_University_StoredPhoto_ProfilePictureId",
                table: "University",
                column: "ProfilePictureId",
                principalTable: "StoredPhoto",
                principalColumn: "Id");
        }
    }
}
