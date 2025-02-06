using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TreatRentRequestChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentHistory",
                table: "RentHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "RentHistoryId",
                table: "StoredPhoto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RentHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttatchedPhotoId",
                table: "RentHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RentHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RentHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RentHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Listing",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentHistory",
                table: "RentHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StoredPhoto_RentHistoryId",
                table: "StoredPhoto",
                column: "RentHistoryId",
                unique: true,
                filter: "[RentHistoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistory_StudentId",
                table: "RentHistory",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoredPhoto_RentHistory_RentHistoryId",
                table: "StoredPhoto",
                column: "RentHistoryId",
                principalTable: "RentHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredPhoto_RentHistory_RentHistoryId",
                table: "StoredPhoto");

            migrationBuilder.DropIndex(
                name: "IX_StoredPhoto_RentHistoryId",
                table: "StoredPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentHistory",
                table: "RentHistory");

            migrationBuilder.DropIndex(
                name: "IX_RentHistory_StudentId",
                table: "RentHistory");

            migrationBuilder.DropColumn(
                name: "RentHistoryId",
                table: "StoredPhoto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RentHistory");

            migrationBuilder.DropColumn(
                name: "AttatchedPhotoId",
                table: "RentHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RentHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RentHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RentHistory");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Listing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentHistory",
                table: "RentHistory",
                columns: new[] { "StudentId", "ListingId" });
        }
    }
}
