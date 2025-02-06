using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRentHistoryStorePhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredPhoto_RentHistory_RentHistoryId",
                table: "StoredPhoto");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttatchedPhotoId",
                table: "RentHistory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StoredPhoto_RentHistory_RentHistoryId",
                table: "StoredPhoto",
                column: "RentHistoryId",
                principalTable: "RentHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredPhoto_RentHistory_RentHistoryId",
                table: "StoredPhoto");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttatchedPhotoId",
                table: "RentHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredPhoto_RentHistory_RentHistoryId",
                table: "StoredPhoto",
                column: "RentHistoryId",
                principalTable: "RentHistory",
                principalColumn: "Id");
        }
    }
}
