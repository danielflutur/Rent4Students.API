using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentPrice = table.Column<int>(type: "int", nullable: false),
                    BuildingYear = table.Column<int>(type: "int", nullable: true),
                    Surface = table.Column<float>(type: "real", nullable: false),
                    DepositAmount = table.Column<int>(type: "int", nullable: true),
                    ListingTypeId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listing_ListingType_ListingTypeId",
                        column: x => x.ListingTypeId,
                        principalTable: "ListingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Listing_PropertyOwner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "PropertyOwner",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LivingAmenity",
                columns: table => new
                {
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListingFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingAmenity", x => new { x.ListingId, x.ListingFeatureId });
                    table.ForeignKey(
                        name: "FK_LivingAmenity_ListingFeature_ListingFeatureId",
                        column: x => x.ListingFeatureId,
                        principalTable: "ListingFeature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LivingAmenity_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PropertyOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_PropertyOwner_PropertyOwnerId",
                        column: x => x.PropertyOwnerId,
                        principalTable: "PropertyOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStorage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MonthlyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStorage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentStorage_DocumentStatus_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "DocumentStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentStorage_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoredPhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PropertyOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoredPhoto_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoredPhoto_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoredPhoto_PropertyOwner_PropertyOwnerId",
                        column: x => x.PropertyOwnerId,
                        principalTable: "PropertyOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_StoredPhoto_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "StoredPhoto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValidated = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                    table.ForeignKey(
                        name: "FK_University_StoredPhoto_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "StoredPhoto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LivingPreference",
                columns: table => new
                {
                    ListingFeatureId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPreference", x => new { x.ListingFeatureId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_LivingPreference_ListingFeature_ListingFeatureId",
                        column: x => x.ListingFeatureId,
                        principalTable: "ListingFeature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LivingPreference_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RentHistory",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentHistory", x => new { x.StudentId, x.ListingId });
                    table.ForeignKey(
                        name: "FK_RentHistory_DocumentStorage_RentDocumentId",
                        column: x => x.RentDocumentId,
                        principalTable: "DocumentStorage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentHistory_Listing_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentHistory_RentStatus_RentStatusId",
                        column: x => x.RentStatusId,
                        principalTable: "RentStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentHistory_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentAttribute",
                columns: table => new
                {
                    UserFeatureId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttribute", x => new { x.UserFeatureId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentAttribute_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentAttribute_UserFeature_UserFeatureId",
                        column: x => x.UserFeatureId,
                        principalTable: "UserFeature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentRoommate",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoommateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRoommate", x => new { x.StudentId, x.RoommateId });
                    table.ForeignKey(
                        name: "FK_StudentRoommate_Student_RoommateId",
                        column: x => x.RoommateId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentRoommate_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DocumentStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Approved" },
                    { 2, "Rejected" },
                    { 3, "Waiting" }
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RentContract" },
                    { 2, "FinancialHelp" }
                });

            migrationBuilder.InsertData(
                table: "ListingFeature",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "FurnishedStatus", "Furnished" },
                    { 2, "FurnishedStatus", "Semi-Furnished" },
                    { 3, "FurnishedStatus", "Unfurnished" },
                    { 4, "NumberOfRooms", "1" },
                    { 5, "NumberOfRooms", "2" },
                    { 6, "NumberOfRooms", "3" },
                    { 7, "NumberOfRooms", "4" },
                    { 8, "AppartmentLayout", "ClosedSpace" },
                    { 9, "AppartmentLayout", "Semi-ClosedSpace" },
                    { 10, "AppartmentLayout", "OpenSpace" },
                    { 11, "Heating", "Central" },
                    { 12, "Heating", "Electrical" },
                    { 13, "Heating", "City Provided" },
                    { 14, "Elevator", "Yes" },
                    { 15, "Elevator", "No" },
                    { 16, "FloorNumber", "Ground" },
                    { 17, "FloorNumber", "1" },
                    { 18, "FloorNumber", "2" },
                    { 19, "FloorNumber", "3" },
                    { 20, "FloorNumber", "4" },
                    { 21, "FloorNumber", "5" },
                    { 22, "FloorNumber", "6" },
                    { 23, "FloorNumber", "7" },
                    { 24, "FloorNumber", "8" },
                    { 25, "FloorNumber", "9" },
                    { 26, "FloorNumber", "10" },
                    { 27, "FloorNumber", "11" },
                    { 28, "FloorNumber", "12" },
                    { 29, "FloorNumber", "13" },
                    { 30, "FloorNumber", "14" },
                    { 31, "FloorNumber", "15" },
                    { 32, "FloorNumber", "16" },
                    { 33, "FloorNumber", "17" },
                    { 34, "FloorNumber", "18" },
                    { 35, "FloorNumber", "19" },
                    { 36, "FloorNumber", "20" },
                    { 37, "PetPolicy", "Allowed" },
                    { 38, "PetPolicy", "Not Allowed" },
                    { 39, "SmokingPolicy", "Allowed" },
                    { 40, "SmokingPolicy", "Not Allowed" },
                    { 41, "RentFelxibility", "Flexible" },
                    { 42, "RentFlexibility", "Fixed-Period" },
                    { 43, "MinimumRentPeriod", "6 months" },
                    { 44, "MinimumRentPeriod", "12 months" },
                    { 45, "Facilities", "Fridge" },
                    { 46, "Facilities", "Microwave" },
                    { 47, "Facilities", "Oven" },
                    { 48, "Facilities", "Stove" },
                    { 49, "Facilities", "Dishwasher" },
                    { 50, "Facilities", "Coffe Maker" },
                    { 51, "Facilities", "Toaster" },
                    { 52, "Facilities", "Kettle" },
                    { 53, "Facilities", "Washing Machine" },
                    { 54, "Facilities", "Dryer" },
                    { 55, "Facilities", "Iron" },
                    { 56, "Facilities", "TV" },
                    { 57, "Facilities", "Furniture" },
                    { 58, "Facilities", "Intercom" },
                    { 59, "Facilities", "Blinds" },
                    { 60, "Facilities", "Internet" },
                    { 61, "Facilities", "Metal Door" },
                    { 62, "Facilities", "AC" },
                    { 63, "Facilities", "Parking Space" },
                    { 64, "BuildingMaterial", "Brick" },
                    { 65, "BuildingMaterial", "BCA" },
                    { 66, "WindowsMaterial", "Wood" },
                    { 67, "WindowsMaterial", "Plastic" },
                    { 68, "Balcony", "No" },
                    { 69, "Balcony", "1" },
                    { 70, "Balcony", "2" },
                    { 71, "Balcony", "3" },
                    { 72, "Balcony", "4" },
                    { 73, "AdditionalStorage", "No" },
                    { 74, "AdditionalStorage", "Basement" },
                    { 75, "AdditionalStorage", "StorageRoom" }
                });

            migrationBuilder.InsertData(
                table: "ListingType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apartament" },
                    { 2, "MicroApartament" },
                    { 3, "Single" },
                    { 4, "Shared" }
                });

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afghan" },
                    { 2, "Albanian" },
                    { 3, "Algerian" },
                    { 4, "American" },
                    { 5, "Andorran" },
                    { 6, "Angolan" },
                    { 7, "Antiguan" },
                    { 8, "Argentine" },
                    { 9, "Armenian" },
                    { 10, "Australian" },
                    { 11, "Austrian" },
                    { 12, "Azerbaijani" },
                    { 13, "Bahamian" },
                    { 14, "Bahraini" },
                    { 15, "Bangladeshi" },
                    { 16, "Barbadian" },
                    { 17, "Belarusian" },
                    { 18, "Belgian" },
                    { 19, "Belizean" },
                    { 20, "Beninese" },
                    { 21, "Bhutanese" },
                    { 22, "Bolivian" },
                    { 23, "Bosnian" },
                    { 24, "Botswanan" },
                    { 25, "Brazilian" },
                    { 26, "British" },
                    { 27, "Bruneian" },
                    { 28, "Bulgarian" },
                    { 29, "Burkinabe" },
                    { 30, "Burmese" },
                    { 31, "Burundian" },
                    { 32, "Cambodian" },
                    { 33, "Cameroonian" },
                    { 34, "Canadian" },
                    { 35, "Cape Verdean" },
                    { 36, "Central African" },
                    { 37, "Chadian" },
                    { 38, "Chilean" },
                    { 39, "Chinese" },
                    { 40, "Colombian" },
                    { 41, "Comorian" },
                    { 42, "Congolese (Congo-Brazzaville)" },
                    { 43, "Congolese (Congo-Kinshasa)" },
                    { 44, "Costa Rican" },
                    { 45, "Croatian" },
                    { 46, "Cuban" },
                    { 47, "Cypriot" },
                    { 48, "Czech" },
                    { 49, "Danish" },
                    { 50, "Djiboutian" },
                    { 51, "Dominican (Dominican Republic)" },
                    { 52, "Dominican (Dominica)" },
                    { 53, "Dutch" },
                    { 54, "East Timorese" },
                    { 55, "Ecuadorian" },
                    { 56, "Egyptian" },
                    { 57, "Emirati" },
                    { 58, "Equatorial Guinean" },
                    { 59, "Eritrean" },
                    { 60, "Estonian" },
                    { 61, "Eswatini (Swazi)" },
                    { 62, "Ethiopian" },
                    { 63, "Fijian" },
                    { 64, "Filipino" },
                    { 65, "Finnish" },
                    { 66, "French" },
                    { 67, "Gabonese" },
                    { 68, "Gambian" },
                    { 69, "Georgian" },
                    { 70, "German" },
                    { 71, "Ghanaian" },
                    { 72, "Greek" },
                    { 73, "Grenadian" },
                    { 74, "Guatemalan" },
                    { 75, "Guinean" },
                    { 76, "Guyanese" },
                    { 77, "Haitian" },
                    { 78, "Honduran" },
                    { 79, "Hungarian" },
                    { 80, "Icelander" },
                    { 81, "Indian" },
                    { 82, "Indonesian" },
                    { 83, "Iranian" },
                    { 84, "Iraqi" },
                    { 85, "Irish" },
                    { 86, "Israeli" },
                    { 87, "Italian" },
                    { 88, "Ivorian" },
                    { 89, "Jamaican" },
                    { 90, "Japanese" },
                    { 91, "Jordanian" },
                    { 92, "Kazakh" },
                    { 93, "Kenyan" },
                    { 94, "Kiribati" },
                    { 95, "Korean (North)" },
                    { 96, "Korean (South)" },
                    { 97, "Kosovar" },
                    { 98, "Kuwaiti" },
                    { 99, "Kyrgyz" },
                    { 100, "Lao" },
                    { 101, "Latvian" },
                    { 102, "Lebanese" },
                    { 103, "Liberian" },
                    { 104, "Libyan" },
                    { 105, "Liechtensteiner" },
                    { 106, "Lithuanian" },
                    { 107, "Luxembourger" },
                    { 108, "Madagascan" },
                    { 109, "Malawian" },
                    { 110, "Malaysian" },
                    { 111, "Maldivian" },
                    { 112, "Malian" },
                    { 113, "Maltese" },
                    { 114, "Marshallese" },
                    { 115, "Mauritanian" },
                    { 116, "Mauritian" },
                    { 117, "Mexican" },
                    { 118, "Micronesian" },
                    { 119, "Moldovan" },
                    { 120, "Monacan" },
                    { 121, "Mongolian" },
                    { 122, "Montenegrin" },
                    { 123, "Moroccan" },
                    { 124, "Mozambican" },
                    { 125, "Namibian" },
                    { 126, "Nauruan" },
                    { 127, "Nepalese" },
                    { 128, "New Zealander" },
                    { 129, "Nicaraguan" },
                    { 130, "Nigerien" },
                    { 131, "Nigerian" },
                    { 132, "Norwegian" },
                    { 133, "Omani" },
                    { 134, "Pakistani" },
                    { 135, "Palauan" },
                    { 136, "Palestinian" },
                    { 137, "Panamanian" },
                    { 138, "Papua New Guinean" },
                    { 139, "Paraguayan" },
                    { 140, "Peruvian" },
                    { 141, "Polish" },
                    { 142, "Portuguese" },
                    { 143, "Qatari" },
                    { 144, "Romanian" },
                    { 145, "Russian" },
                    { 146, "Rwandan" },
                    { 147, "Saint Lucian" },
                    { 148, "Salvadoran" },
                    { 149, "Samoan" },
                    { 150, "San Marinese" },
                    { 151, "Sao Tomean" },
                    { 152, "Saudi" },
                    { 153, "Senegalese" },
                    { 154, "Serbian" },
                    { 155, "Seychellois" },
                    { 156, "Sierra Leonean" },
                    { 157, "Singaporean" },
                    { 158, "Slovak" },
                    { 159, "Slovenian" },
                    { 160, "Solomon Islander" },
                    { 161, "Somali" },
                    { 162, "South African" },
                    { 163, "South Sudanese" },
                    { 164, "Spanish" },
                    { 165, "Sri Lankan" },
                    { 166, "Sudanese" },
                    { 167, "Surinamese" },
                    { 168, "Swedish" },
                    { 169, "Swiss" },
                    { 170, "Syrian" },
                    { 171, "Tajik" },
                    { 172, "Tanzanian" },
                    { 173, "Thai" },
                    { 174, "Togolese" },
                    { 175, "Tongan" },
                    { 176, "Trinidadian/Tobagonian" },
                    { 177, "Tunisian" },
                    { 178, "Turkish" },
                    { 179, "Turkmen" },
                    { 180, "Tuvaluan" },
                    { 181, "Ugandan" },
                    { 182, "Ukrainian" },
                    { 183, "Uruguayan" },
                    { 184, "Uzbek" },
                    { 185, "Vanuatuan" },
                    { 186, "Vatican" },
                    { 187, "Venezuelan" },
                    { 188, "Vietnamese" },
                    { 189, "Yemeni" },
                    { 190, "Zambian" },
                    { 191, "Zimbabwean" }
                });

            migrationBuilder.InsertData(
                table: "RentStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "UserFeature",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Gender", "Male" },
                    { 2, "Gender", "Female" },
                    { 3, "Gender", "Other" },
                    { 4, "Occupation", "Part-Time Job" },
                    { 5, "Occupation", "Full-Time Job" },
                    { 6, "Occupation", "Student" },
                    { 7, "YearOfStudy", "1" },
                    { 8, "YearOfStudy", "2" },
                    { 9, "YearOfStudy", "3" },
                    { 10, "YearOfStudy", "4" },
                    { 11, "YearOfStudy", "5" },
                    { 12, "YearOfStudy", "6" },
                    { 13, "ReligiousBeliefs", "Orthodoxy" },
                    { 14, "ReligiousBeliefs", "Romano Catholicism" },
                    { 15, "ReligiousBeliefs", "Greek Catholicism" },
                    { 16, "ReligiousBeliefs", "Calvinist" },
                    { 17, "ReligiousBeliefs", "Lutheran" },
                    { 18, "ReligiousBeliefs", "Pentecostal Christian" },
                    { 19, "ReligiousBeliefs", "Islam" },
                    { 20, "ReligiousBeliefs", "Judaism" },
                    { 21, "ReligiousBeliefs", "Baptist" },
                    { 22, "ReligiousBeliefs", "Atheism/Agnosticism" },
                    { 23, "ReligiousBeliefs", "Adventist" },
                    { 24, "ReligiousBeliefs", "Jehovah’s Witnesses" },
                    { 25, "ReligiousBeliefs", "Buddhism" },
                    { 26, "ReligiousBeliefs", "Hindu" },
                    { 27, "ReligiousBeliefs", "Other" },
                    { 28, "DietaryPreferences", "No Preferences" },
                    { 29, "DietaryPreferences", "Vegetarian" },
                    { 30, "DietaryPreferences", "Vegan" },
                    { 31, "DietaryPreferences", "Pescatarian" },
                    { 32, "DietaryPreferences", "Gluten-Free" },
                    { 33, "DietaryPreferences", "Lactose-Free" },
                    { 34, "DietaryPreferences", "Keto" },
                    { 35, "DietaryPreferences", "Diabetic-Friendly" },
                    { 36, "DietaryPreferences", "Halal" },
                    { 37, "DietaryPreferences", "Kosher" },
                    { 38, "DietaryPreferences", "Organic" },
                    { 39, "DietaryPreferences", "Other" },
                    { 40, "Allergies", "No Allergies" },
                    { 41, "Allergies", "Peanuts/Nuts" },
                    { 42, "Allergies", "Dairy" },
                    { 43, "Allergies", "Eggs" },
                    { 44, "Allergies", "Wheat" },
                    { 45, "Allergies", "Soy" },
                    { 46, "Allergies", "Fish" },
                    { 47, "Allergies", "Pollen" },
                    { 48, "Allergies", "Dust Mites" },
                    { 49, "Allergies", "Mold" },
                    { 50, "Allergies", "Cats" },
                    { 51, "Allergies", "Dogs" },
                    { 52, "Allergies", "Latex" },
                    { 53, "Allergies", "Fragrances" },
                    { 54, "Allergies", "Cosmetic Products" },
                    { 55, "Allergies", "Detergents and Soaps" },
                    { 56, "Allergies", "Bee Stings" },
                    { 57, "Allergies", "Wasp Stings" },
                    { 58, "Allergies", "Ant Stings" },
                    { 59, "Allergies", "Medications" },
                    { 60, "Allergies", "Other" },
                    { 61, "SleepingHours", "Early Bird" },
                    { 62, "SleepingHours", "Night Owl" },
                    { 63, "SleepingHours", "Flexible" },
                    { 64, "SleepingHours", "Other" },
                    { 65, "SmokingHabbits", "Smoker" },
                    { 66, "SmokingHabbits", "Non-Smoker" },
                    { 67, "SmokingHabbits", "Doesn't Mind" },
                    { 68, "AlcoholConsumption", "Regular" },
                    { 69, "AlcoholConsumption", "Social" },
                    { 70, "AlcoholConsumption", "Rarely" },
                    { 71, "AlcoholConsumption", "Never" },
                    { 72, "PetOwnership", "No" },
                    { 73, "PetOwnership", "Cat" },
                    { 74, "PetOwnership", "Dog" },
                    { 75, "PetOwnership", "Bird" },
                    { 76, "PetOwnership", "Fish" },
                    { 77, "PetOwnership", "Rodent" },
                    { 78, "PetOwnership", "Other" },
                    { 79, "PetPreferences", "Likes Pets" },
                    { 80, "PetPreferences", "Doesn't Likes Pets" },
                    { 81, "PetPreferences", "Allergic" },
                    { 82, "PetPreferences", "No Preference" },
                    { 83, "NoiseTolerance", "Quiet" },
                    { 84, "NoiseTolerance", "Moderate" },
                    { 85, "NoiseTolerance", "Doesn't Mind" },
                    { 86, "CleanlinessLevel", "Very Clean" },
                    { 87, "CleanlinessLevel", "Moderate" },
                    { 88, "CleanlinessLevel", "Laid-Back" },
                    { 89, "CookingHabbits", "Loves Cooking" },
                    { 90, "CookingHabbits", "Cooks Occasionally" },
                    { 91, "CookingHabbits", "Doesn't Cook" },
                    { 92, "PreferedLivingArrangement", "Private Room" },
                    { 93, "PreferedLivingArrangement", "Shared Room" },
                    { 94, "PreferedLivingArrangement", "Doesn't Mind" },
                    { 95, "Hobbies", "Drawing" },
                    { 96, "Hobbies", "Painting" },
                    { 97, "Hobbies", "Singing" },
                    { 98, "Hobbies", "Calligraphy" },
                    { 99, "Hobbies", "Photography" },
                    { 100, "Hobbies", "Graphic Design" },
                    { 101, "Hobbies", "Playing an Instrument" },
                    { 102, "Hobbies", "Knitting/Crocheting" },
                    { 103, "Hobbies", "Sewing/Fashion Design" },
                    { 104, "Hobbies", "Dancing" },
                    { 105, "Hobbies", "Stand-up Comedy" },
                    { 106, "Hobbies", "Magic Tricks" },
                    { 107, "Hobbies", "Writing" },
                    { 108, "Hobbies", "Reading" },
                    { 109, "Hobbies", "Blogging" },
                    { 110, "Hobbies", "Running/Jogging" },
                    { 111, "Hobbies", "Yoga" },
                    { 112, "Hobbies", "Pilates" },
                    { 113, "Hobbies", "Swimming" },
                    { 114, "Hobbies", "Hiking" },
                    { 115, "Hobbies", "Cycling" },
                    { 116, "Hobbies", "Martial Arts" },
                    { 117, "Hobbies", "Football" },
                    { 118, "Hobbies", "Basketball" },
                    { 119, "Hobbies", "Volleyball" },
                    { 120, "Hobbies", "Handball" },
                    { 121, "Hobbies", "Rock Climbing" },
                    { 122, "Hobbies", "Gymnastics" },
                    { 123, "Hobbies", "Gaming" },
                    { 124, "Hobbies", "Programming/Coding" },
                    { 125, "Hobbies", "Robotics" },
                    { 126, "Hobbies", "VR" },
                    { 127, "Hobbies", "3D Printing" },
                    { 128, "Hobbies", "Drone Flying" },
                    { 129, "Hobbies", "Cooking" },
                    { 130, "Hobbies", "Baking" },
                    { 131, "Hobbies", "Coffee Brewing" },
                    { 132, "Hobbies", "Cake Decorating" },
                    { 133, "Hobbies", "Gardening" },
                    { 134, "Hobbies", "Bird Watching" },
                    { 135, "Hobbies", "Camping" },
                    { 136, "Hobbies", "Fishing" },
                    { 137, "Hobbies", "Geocaching" },
                    { 138, "Hobbies", "Stargazingg" },
                    { 139, "Hobbies", "Collecting Stamps" },
                    { 140, "Hobbies", "Coin Collecting" },
                    { 141, "Hobbies", "Collecting Action Figures" },
                    { 142, "Hobbies", "Vinyl Records Collecting" },
                    { 143, "Hobbies", "Fossil or Rock Collecting" },
                    { 144, "Hobbies", "Model Building" },
                    { 145, "Hobbies", "Origami" },
                    { 146, "Hobbies", "Beadwork" },
                    { 147, "Hobbies", "Puzzles" },
                    { 148, "Hobbies", "Chess" },
                    { 149, "Hobbies", "Sudoku" },
                    { 150, "Hobbies", "Traveling" },
                    { 151, "Hobbies", "Road Tripping" },
                    { 152, "Hobbies", "Backpacking" },
                    { 153, "Hobbies", "Movie Watching" },
                    { 154, "Hobbies", "Podcasting" },
                    { 155, "Hobbies", "Streaming/Content Creation" },
                    { 156, "Hobbies", "Astrology" },
                    { 157, "Hobbies", "Cosplaying" },
                    { 158, "Hobbies", "Parkour" },
                    { 159, "Hobbies", "Other" },
                    { 160, "ExerciseRoutine", "Gym Regular" },
                    { 161, "ExerciseRoutine", "Outdoor Activities" },
                    { 162, "ExerciseRoutine", "Doesn't Exercise Regularly" },
                    { 163, "SocialHabbits", "Outgoing" },
                    { 164, "SocialHabbits", "Introverted" },
                    { 165, "SocialHabbits", "Balanced" },
                    { 166, "PrefferedRoommateGender", "Same Gender" },
                    { 167, "PrefferedRoommateGender", "No Preference" },
                    { 168, "GuestsTolerance", "Frequent Visitors" },
                    { 169, "GuestsTolerance", "Rarely" },
                    { 170, "GuestsTolerance", "No Visitors" },
                    { 171, "StudyEnvironment", "Quiet" },
                    { 172, "StudyEnvironment", "Collaborative" },
                    { 173, "StudyEnvironment", "No Preference" },
                    { 174, "PrefferedCommunicationMeans", "Text" },
                    { 175, "PrefferedCommunicationMeans", "Calls" },
                    { 176, "PrefferedCommunicationMeans", "Face-to-face" },
                    { 177, "PersonalityType", "Intorvert" },
                    { 178, "PersonalityType", "Extrovert" },
                    { 179, "ConflictResolutionStyle", "Direct" },
                    { 180, "ConflictResolutionStyle", "Passive" },
                    { 181, "ConflictResolutionStyle", "Mediator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_FacultyId",
                table: "Address",
                column: "FacultyId",
                unique: true,
                filter: "[FacultyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ListingId",
                table: "Address",
                column: "ListingId",
                unique: true,
                filter: "[ListingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PropertyOwnerId",
                table: "Address",
                column: "PropertyOwnerId",
                unique: true,
                filter: "[PropertyOwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UniversityId",
                table: "Address",
                column: "UniversityId",
                unique: true,
                filter: "[UniversityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStorage_DocumentStatusId",
                table: "DocumentStorage",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStorage_DocumentTypeId",
                table: "DocumentStorage",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStorage_FacultyId",
                table: "DocumentStorage",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStorage_StudentId",
                table: "DocumentStorage",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_UniversityId",
                table: "Faculty",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ListingTypeId",
                table: "Listing",
                column: "ListingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_OwnerID",
                table: "Listing",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LivingAmenity_ListingFeatureId",
                table: "LivingAmenity",
                column: "ListingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_LivingPreference_StudentId",
                table: "LivingPreference",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistory_ListingId",
                table: "RentHistory",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistory_RentDocumentId",
                table: "RentHistory",
                column: "RentDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistory_RentStatusId",
                table: "RentHistory",
                column: "RentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredPhoto_FacultyId",
                table: "StoredPhoto",
                column: "FacultyId",
                unique: true,
                filter: "[FacultyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoredPhoto_ListingId",
                table: "StoredPhoto",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredPhoto_PropertyOwnerId",
                table: "StoredPhoto",
                column: "PropertyOwnerId",
                unique: true,
                filter: "[PropertyOwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FacultyId",
                table: "Student",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_NationalityId",
                table: "Student",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProfilePictureId",
                table: "Student",
                column: "ProfilePictureId",
                unique: true,
                filter: "[ProfilePictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttribute_StudentId",
                table: "StudentAttribute",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRoommate_RoommateId",
                table: "StudentRoommate",
                column: "RoommateId");

            migrationBuilder.CreateIndex(
                name: "IX_University_ProfilePictureId",
                table: "University",
                column: "ProfilePictureId",
                unique: true,
                filter: "[ProfilePictureId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Faculty_FacultyId",
                table: "Address",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_University_UniversityId",
                table: "Address",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Faculty_University_UniversityId",
                table: "Faculty",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredPhoto_Faculty_FacultyId",
                table: "StoredPhoto");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "LivingAmenity");

            migrationBuilder.DropTable(
                name: "LivingPreference");

            migrationBuilder.DropTable(
                name: "RentHistory");

            migrationBuilder.DropTable(
                name: "StudentAttribute");

            migrationBuilder.DropTable(
                name: "StudentRoommate");

            migrationBuilder.DropTable(
                name: "ListingFeature");

            migrationBuilder.DropTable(
                name: "DocumentStorage");

            migrationBuilder.DropTable(
                name: "RentStatus");

            migrationBuilder.DropTable(
                name: "UserFeature");

            migrationBuilder.DropTable(
                name: "DocumentStatus");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "StoredPhoto");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "ListingType");

            migrationBuilder.DropTable(
                name: "PropertyOwner");
        }
    }
}
