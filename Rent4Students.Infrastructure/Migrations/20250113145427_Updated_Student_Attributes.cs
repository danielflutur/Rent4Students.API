using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rent4Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Student_Attributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAttribute");

            migrationBuilder.DropTable(
                name: "UserFeature");

            migrationBuilder.DropColumn(
                name: "AppartmentNumber",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Address",
                newName: "AddressDetails");

            migrationBuilder.RenameColumn(
                name: "FloorNumber",
                table: "Address",
                newName: "GoogleMaps");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearOfStudy",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAllergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAllergies", x => new { x.AllergyId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentAllergies_Allergy_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentAllergies_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentHobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHobbies", x => new { x.StudentId, x.HobbyId });
                    table.ForeignKey(
                        name: "FK_StudentHobbies_Hobby_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobby",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentHobbies_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentAttributes",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttributes", x => new { x.StudentId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_StudentAttributes_PersonalityAttribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "PersonalityAttribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentAttributes_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Allergy",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "No Allergies" },
                    { 2, "Peanuts/Nuts" },
                    { 3, "Dairy" },
                    { 4, "Eggs" },
                    { 5, "Wheat" },
                    { 6, "Soy" },
                    { 7, "Fish" },
                    { 8, "Pollen" },
                    { 9, "Dust Mites" },
                    { 10, "Mold" },
                    { 11, "Cats" },
                    { 12, "Dogs" },
                    { 13, "Latex" },
                    { 14, "Fragrances" },
                    { 15, "Cosmetic Products" },
                    { 16, "Detergents and Soaps" },
                    { 17, "Bee Stings" },
                    { 18, "Wasp Stings" },
                    { 19, "Ant Stings" },
                    { 20, "Medications" },
                    { 21, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Hobby",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Painting" },
                    { 2, "Singing" },
                    { 3, "Calligraphy" },
                    { 4, "Photography" },
                    { 5, "Graphic Design" },
                    { 6, "Playing an Instrument" },
                    { 7, "Knitting/Crocheting" },
                    { 8, "Sewing/Fashion Design" },
                    { 9, "Dancing" },
                    { 10, "Stand-up Comedy" },
                    { 11, "Magic Tricks" },
                    { 12, "Writing" },
                    { 13, "Reading" },
                    { 14, "Blogging" },
                    { 15, "Running/Jogging" },
                    { 16, "Yoga" },
                    { 17, "Pilates" },
                    { 18, "Swimming" },
                    { 19, "Hiking" },
                    { 20, "Cycling" },
                    { 21, "Martial Arts" },
                    { 22, "Football" },
                    { 23, "Basketball" },
                    { 24, "Volleyball" },
                    { 25, "Handball" },
                    { 26, "Rock Climbing" },
                    { 27, "Gymnastics" },
                    { 28, "Gaming" },
                    { 29, "Programming/Coding" },
                    { 30, "Drawing" },
                    { 31, "Robotics" },
                    { 32, "VR" },
                    { 33, "3D Printing" },
                    { 34, "Drone Flying" },
                    { 35, "Cooking" },
                    { 36, "Baking" },
                    { 37, "Coffee Brewing" },
                    { 38, "Cake Decorating" },
                    { 39, "Gardening" },
                    { 40, "Bird Watching" },
                    { 41, "Camping" },
                    { 42, "Fishing" },
                    { 43, "Geocaching" },
                    { 44, "Stargazingg" },
                    { 45, "Collecting Stamps" },
                    { 46, "Coin Collecting" },
                    { 47, "Collecting Action Figures" },
                    { 48, "Vinyl Records Collecting" },
                    { 49, "Fossil or Rock Collecting" },
                    { 50, "Model Building" },
                    { 51, "Origami" },
                    { 52, "Beadwork" },
                    { 53, "Puzzles" },
                    { 54, "Chess" },
                    { 55, "Sudoku" },
                    { 56, "Traveling" },
                    { 57, "Road Tripping" },
                    { 58, "Backpacking" },
                    { 59, "Movie Watching" },
                    { 60, "Podcasting" },
                    { 61, "Streaming/Content Creation" },
                    { 62, "Astrology" },
                    { 63, "Cosplaying" },
                    { 64, "Parkour" },
                    { 65, "Other" }
                });

            migrationBuilder.InsertData(
                table: "PersonalityAttribute",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Occupation", "Part-Time Job" },
                    { 2, "Occupation", "Full-Time Job" },
                    { 3, "Occupation", "Student" },
                    { 4, "ReligiousBeliefs", "Orthodoxy" },
                    { 5, "ReligiousBeliefs", "Romano Catholicism" },
                    { 6, "ReligiousBeliefs", "Greek Catholicism" },
                    { 7, "ReligiousBeliefs", "Calvinist" },
                    { 8, "ReligiousBeliefs", "Lutheran" },
                    { 9, "ReligiousBeliefs", "Pentecostal Christian" },
                    { 10, "ReligiousBeliefs", "Islam" },
                    { 11, "ReligiousBeliefs", "Judaism" },
                    { 12, "ReligiousBeliefs", "Baptist" },
                    { 13, "ReligiousBeliefs", "Atheism/Agnosticism" },
                    { 14, "ReligiousBeliefs", "Adventist" },
                    { 15, "ReligiousBeliefs", "Jehovah’s Witnesses" },
                    { 16, "ReligiousBeliefs", "Buddhism" },
                    { 17, "ReligiousBeliefs", "Hindu" },
                    { 18, "ReligiousBeliefs", "Other" },
                    { 19, "DietaryPreferences", "No Preferences" },
                    { 20, "DietaryPreferences", "Vegetarian" },
                    { 21, "DietaryPreferences", "Vegan" },
                    { 22, "DietaryPreferences", "Pescatarian" },
                    { 23, "DietaryPreferences", "Gluten-Free" },
                    { 24, "DietaryPreferences", "Lactose-Free" },
                    { 25, "DietaryPreferences", "Keto" },
                    { 26, "DietaryPreferences", "Diabetic-Friendly" },
                    { 27, "DietaryPreferences", "Halal" },
                    { 28, "DietaryPreferences", "Kosher" },
                    { 29, "DietaryPreferences", "Organic" },
                    { 30, "DietaryPreferences", "Other" },
                    { 31, "SleepingHours", "Early Bird" },
                    { 32, "SleepingHours", "Night Owl" },
                    { 33, "SleepingHours", "Flexible" },
                    { 34, "SleepingHours", "Other" },
                    { 35, "SmokingHabbits", "Smoker" },
                    { 36, "SmokingHabbits", "Non-Smoker" },
                    { 37, "SmokingHabbits", "Doesn't Mind" },
                    { 38, "AlcoholConsumption", "Regular" },
                    { 39, "AlcoholConsumption", "Social" },
                    { 40, "AlcoholConsumption", "Rarely" },
                    { 41, "AlcoholConsumption", "Never" },
                    { 42, "PetOwnership", "No" },
                    { 43, "PetOwnership", "Cat" },
                    { 44, "PetOwnership", "Dog" },
                    { 45, "PetOwnership", "Bird" },
                    { 46, "PetOwnership", "Fish" },
                    { 47, "PetOwnership", "Rodent" },
                    { 48, "PetOwnership", "Other" },
                    { 49, "PetPreferences", "Likes Pets" },
                    { 50, "PetPreferences", "Doesn't Likes Pets" },
                    { 51, "PetPreferences", "Allergic" },
                    { 52, "PetPreferences", "No Preference" },
                    { 53, "NoiseTolerance", "Quiet" },
                    { 54, "NoiseTolerance", "Moderate" },
                    { 55, "NoiseTolerance", "Doesn't Mind" },
                    { 56, "CleanlinessLevel", "Very Clean" },
                    { 57, "CleanlinessLevel", "Moderate" },
                    { 58, "CleanlinessLevel", "Laid-Back" },
                    { 59, "CookingHabbits", "Loves Cooking" },
                    { 60, "CookingHabbits", "Cooks Occasionally" },
                    { 61, "CookingHabbits", "Doesn't Cook" },
                    { 62, "PreferedLivingArrangement", "Private Room" },
                    { 63, "PreferedLivingArrangement", "Shared Room" },
                    { 64, "PreferedLivingArrangement", "Doesn't Mind" },
                    { 65, "ExerciseRoutine", "Gym Regular" },
                    { 66, "ExerciseRoutine", "Outdoor Activities" },
                    { 67, "ExerciseRoutine", "Doesn't Exercise Regularly" },
                    { 68, "SocialHabbits", "Outgoing" },
                    { 69, "SocialHabbits", "Introverted" },
                    { 70, "SocialHabbits", "Balanced" },
                    { 71, "PrefferedRoommateGender", "Same Gender" },
                    { 72, "PrefferedRoommateGender", "No Preference" },
                    { 73, "GuestsTolerance", "Frequent Visitors" },
                    { 74, "GuestsTolerance", "Rarely" },
                    { 75, "GuestsTolerance", "No Visitors" },
                    { 76, "StudyEnvironment", "Quiet" },
                    { 77, "StudyEnvironment", "Collaborative" },
                    { 78, "StudyEnvironment", "No Preference" },
                    { 79, "PrefferedCommunicationMeans", "Text" },
                    { 80, "PrefferedCommunicationMeans", "Calls" },
                    { 81, "PrefferedCommunicationMeans", "Face-to-face" },
                    { 82, "PersonalityType", "Intorvert" },
                    { 83, "PersonalityType", "Extrovert" },
                    { 84, "ConflictResolutionStyle", "Direct" },
                    { 85, "ConflictResolutionStyle", "Passive" },
                    { 86, "ConflictResolutionStyle", "Mediator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_GenderId",
                table: "Student",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAllergies_StudentId",
                table: "StudentAllergies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttributes_AttributeId",
                table: "StudentAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbies_HobbyId",
                table: "StudentHobbies",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Gender_GenderId",
                table: "Student",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Gender_GenderId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "StudentAllergies");

            migrationBuilder.DropTable(
                name: "StudentAttributes");

            migrationBuilder.DropTable(
                name: "StudentHobbies");

            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "PersonalityAttribute");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropIndex(
                name: "IX_Student_GenderId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "YearOfStudy",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "GoogleMaps",
                table: "Address",
                newName: "FloorNumber");

            migrationBuilder.RenameColumn(
                name: "AddressDetails",
                table: "Address",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<string>(
                name: "AppartmentNumber",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingNumber",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeature", x => x.Id);
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
                name: "IX_StudentAttribute_StudentId",
                table: "StudentAttribute",
                column: "StudentId");
        }
    }
}
