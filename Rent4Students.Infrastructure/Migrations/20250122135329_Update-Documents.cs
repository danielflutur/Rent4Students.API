using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentStorage_DocumentStatus_DocumentStatusId",
                table: "DocumentStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentStorage_DocumentType_DocumentTypeId",
                table: "DocumentStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentStorage_Faculty_FacultyId",
                table: "DocumentStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentStorage_Student_StudentId",
                table: "DocumentStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_RentHistory_DocumentStorage_RentDocumentId",
                table: "RentHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentStorage",
                table: "DocumentStorage");

            migrationBuilder.DropIndex(
                name: "IX_DocumentStorage_FacultyId",
                table: "DocumentStorage");

            migrationBuilder.DropIndex(
                name: "IX_DocumentStorage_StudentId",
                table: "DocumentStorage");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DocumentStorage");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "DocumentStorage");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "DocumentStorage");

            migrationBuilder.RenameTable(
                name: "DocumentStorage",
                newName: "RentDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentStorage_DocumentTypeId",
                table: "RentDocuments",
                newName: "IX_RentDocuments_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentStorage_DocumentStatusId",
                table: "RentDocuments",
                newName: "IX_RentDocuments_DocumentStatusId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RentDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentPaymentDate",
                table: "RentDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyRent",
                table: "RentDocuments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "RentDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DepositAmount",
                table: "RentDocuments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalDetails",
                table: "RentDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentDocuments",
                table: "RentDocuments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FinancialHelpDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialHelpDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialHelpDocument_DocumentStatus_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "DocumentStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialHelpDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialHelpDocument_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialHelpDocument_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialHelpDocument_DocumentStatusId",
                table: "FinancialHelpDocument",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialHelpDocument_DocumentTypeId",
                table: "FinancialHelpDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialHelpDocument_FacultyId",
                table: "FinancialHelpDocument",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialHelpDocument_StudentId",
                table: "FinancialHelpDocument",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentDocuments_DocumentStatus_DocumentStatusId",
                table: "RentDocuments",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentDocuments_DocumentType_DocumentTypeId",
                table: "RentDocuments",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentHistory_RentDocuments_RentDocumentId",
                table: "RentHistory",
                column: "RentDocumentId",
                principalTable: "RentDocuments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentDocuments_DocumentStatus_DocumentStatusId",
                table: "RentDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_RentDocuments_DocumentType_DocumentTypeId",
                table: "RentDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_RentHistory_RentDocuments_RentDocumentId",
                table: "RentHistory");

            migrationBuilder.DropTable(
                name: "FinancialHelpDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentDocuments",
                table: "RentDocuments");

            migrationBuilder.RenameTable(
                name: "RentDocuments",
                newName: "DocumentStorage");

            migrationBuilder.RenameIndex(
                name: "IX_RentDocuments_DocumentTypeId",
                table: "DocumentStorage",
                newName: "IX_DocumentStorage_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RentDocuments_DocumentStatusId",
                table: "DocumentStorage",
                newName: "IX_DocumentStorage_DocumentStatusId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "DocumentStorage",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentPaymentDate",
                table: "DocumentStorage",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyRent",
                table: "DocumentStorage",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "DocumentStorage",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "DepositAmount",
                table: "DocumentStorage",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalDetails",
                table: "DocumentStorage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DocumentStorage",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FacultyId",
                table: "DocumentStorage",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "DocumentStorage",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentStorage",
                table: "DocumentStorage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStorage_FacultyId",
                table: "DocumentStorage",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStorage_StudentId",
                table: "DocumentStorage",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentStorage_DocumentStatus_DocumentStatusId",
                table: "DocumentStorage",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentStorage_DocumentType_DocumentTypeId",
                table: "DocumentStorage",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentStorage_Faculty_FacultyId",
                table: "DocumentStorage",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentStorage_Student_StudentId",
                table: "DocumentStorage",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentHistory_DocumentStorage_RentDocumentId",
                table: "RentHistory",
                column: "RentDocumentId",
                principalTable: "DocumentStorage",
                principalColumn: "Id");
        }
    }
}
