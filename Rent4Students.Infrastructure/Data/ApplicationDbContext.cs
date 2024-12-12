using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Configurations;
using Rent4Students.Domain.Configurations.Enums;
using Rent4Students.Domain.Configurations.Joined;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;

namespace Rent4Students.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<University> University { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StoredPhoto> StoredPhoto { get; set; }
        public DbSet<RentDocument> RentDocuments { get; set; }
        public DbSet<PropertyOwner> PropertyOwner { get; set; }
        public DbSet<Listing> Listing { get; set; }
        public DbSet<FinancialHelpDocument> FinancialHelpDocument { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<DocumentStorage> DocumentStorage { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<DocumentStatus> DocumentStatus { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<ListingFeature> ListingFeature { get; set; }
        public DbSet<ListingType> ListingType { get; set; }
        public DbSet<RentStatus> RentStatus { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<UserFeature> UserFeature { get; set; }
        public DbSet<LivingAmenity> LivingAmenity { get; set; }
        public DbSet<LivingPreference> LivingPreference { get; set; }
        public DbSet<RentHistory> RentHistory { get; set; }
        public DbSet<StudentAttribute> StudentAttribute { get; set; }
        public DbSet<StudentRoommate> StudentRoommate { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UniversityConfiguration().Configure(modelBuilder.Entity<University>());
            new StudentConfiguration().Configure(modelBuilder.Entity<Student>());
            new StoredPhotoConfiguration().Configure(modelBuilder.Entity<StoredPhoto>());
            new RentDocumentConfiguration().Configure(modelBuilder.Entity<RentDocument>());
            new PropertyOwnerConfiguration().Configure(modelBuilder.Entity<PropertyOwner>());
            new ListingConfiguration().Configure(modelBuilder.Entity<Listing>());
            new FinancialHelpDocumentConfiguration().Configure(modelBuilder.Entity<FinancialHelpDocument>());
            new FacultyConfiguration().Configure(modelBuilder.Entity<Faculty>());
            new DocumentStorageConfiguration().Configure(modelBuilder.Entity<DocumentStorage>());
            new AgencyConfiguration().Configure(modelBuilder.Entity<Agency>());
            new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
            new DocumentStatusConfiguration().Configure(modelBuilder.Entity<DocumentStatus>());
            new DocumentTypeConfiguration().Configure(modelBuilder.Entity<DocumentType>());
            new ListingFeatureConfiguration().Configure(modelBuilder.Entity<ListingFeature>());
            new ListingTypeConfiguration().Configure(modelBuilder.Entity<ListingType>());
            new RentStatusConfiguration().Configure(modelBuilder.Entity<RentStatus>());
            new NationalityConfiguration().Configure(modelBuilder.Entity<Nationality>());
            new UserFeatureConfiguration().Configure(modelBuilder.Entity<UserFeature>());
            new LivingAmenityConfiguration().Configure(modelBuilder.Entity<LivingAmenity>());
            new LivingPreferenceConfiguration().Configure(modelBuilder.Entity<LivingPreference>());
            new RentHistoryConfiguration().Configure(modelBuilder.Entity<RentHistory>());
            new StudentAttributeConfiguration().Configure(modelBuilder.Entity<StudentAttribute>());
            new StudentRoommateConfiguration().Configure(modelBuilder.Entity<StudentRoommate>());

            AddDefaultEnums(modelBuilder);
        }

        private void AddDefaultEnums(ModelBuilder modelBuilder)
        {
            AddDocumentStatuses(modelBuilder);
            AddDocumentTypes(modelBuilder);
            AddListingFeatures(modelBuilder);
            AddListingTypes(modelBuilder);
            AddRentStatuses(modelBuilder);
            AddNationalities(modelBuilder);
            AddUserFeatures(modelBuilder);
        }

        private void AddDocumentStatuses(ModelBuilder modelBuilder)
        {
            var approved = new DocumentStatus { Id = 1, Name = "Approved" };
            var rejected = new DocumentStatus { Id = 2, Name = "Rejected" };
            var waiting = new DocumentStatus { Id = 3, Name = "Waiting" };
            
            modelBuilder.Entity<DocumentStatus>().HasData(approved, rejected, waiting);
        }

        private void AddDocumentTypes(ModelBuilder modelBuilder)
        {
            var rentContract = new DocumentType { Id = 1, Name = "RentContract" };
            var financialHelp = new DocumentType { Id = 2, Name = "FinancialHelp" };
            
            modelBuilder.Entity<DocumentType>().HasData(rentContract, financialHelp); 
        }

        private void AddListingFeatures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListingFeature>().HasData
            (
                new ListingFeature { Id = 1, Name = "FurnishedStatus", Value = "Furnished" },
                new ListingFeature { Id = 2, Name = "FurnishedStatus", Value = "Semi-Furnished" },
                new ListingFeature { Id = 3, Name = "FurnishedStatus", Value = "Unfurnished" },
                new ListingFeature { Id = 4, Name = "NumberOfRooms", Value = "1" },
                new ListingFeature { Id = 5, Name = "NumberOfRooms", Value = "2" },
                new ListingFeature { Id = 6, Name = "NumberOfRooms", Value = "3" },
                new ListingFeature { Id = 7, Name = "NumberOfRooms", Value = "4" },
                new ListingFeature { Id = 8, Name = "AppartmentLayout", Value = "ClosedSpace" },
                new ListingFeature { Id = 9, Name = "AppartmentLayout", Value = "Semi-ClosedSpace" },
                new ListingFeature { Id = 10, Name = "AppartmentLayout", Value = "OpenSpace" },
                new ListingFeature { Id = 11, Name = "Heating", Value = "Central" },
                new ListingFeature { Id = 12, Name = "Heating", Value = "Electrical" },
                new ListingFeature { Id = 13, Name = "Heating", Value = "City Provided" },
                new ListingFeature { Id = 14, Name = "Elevator", Value = "Yes" },
                new ListingFeature { Id = 15, Name = "Elevator", Value= "No" },
                new ListingFeature { Id = 16, Name = "FloorNumber", Value = "Ground" },
                new ListingFeature { Id = 17, Name = "FloorNumber", Value = "1" },
                new ListingFeature { Id = 18, Name = "FloorNumber", Value = "2" },
                new ListingFeature { Id = 19, Name = "FloorNumber", Value = "3" },
                new ListingFeature { Id = 20, Name = "FloorNumber", Value = "4" },
                new ListingFeature { Id = 21, Name = "FloorNumber", Value = "5" },
                new ListingFeature { Id = 22, Name = "FloorNumber", Value = "6" },
                new ListingFeature { Id = 23, Name = "FloorNumber", Value = "7" },
                new ListingFeature { Id = 24, Name = "FloorNumber", Value = "8" },
                new ListingFeature { Id = 25, Name = "FloorNumber", Value = "9" },
                new ListingFeature { Id = 26, Name = "FloorNumber", Value = "10" },
                new ListingFeature { Id = 27, Name = "FloorNumber", Value = "11" },
                new ListingFeature { Id = 28, Name = "FloorNumber", Value = "12" },
                new ListingFeature { Id = 29, Name = "FloorNumber", Value = "13" },
                new ListingFeature { Id = 30, Name = "FloorNumber", Value = "14" },
                new ListingFeature { Id = 31, Name = "FloorNumber", Value = "15" },
                new ListingFeature { Id = 32, Name = "FloorNumber", Value = "16" },
                new ListingFeature { Id = 33, Name = "FloorNumber", Value = "17" },
                new ListingFeature { Id = 34, Name = "FloorNumber", Value = "18" },
                new ListingFeature { Id = 35, Name = "FloorNumber", Value = "19" },
                new ListingFeature { Id = 36, Name = "FloorNumber", Value = "20" },
                new ListingFeature { Id = 37, Name = "PetPolicy", Value = "Allowed" },
                new ListingFeature { Id = 38, Name = "PetPolicy", Value = "Not Allowed" },
                new ListingFeature { Id = 39, Name = "SmokingPolicy", Value = "Allowed" },
                new ListingFeature { Id = 40, Name = "SmokingPolicy", Value = "Not Allowed" },
                new ListingFeature { Id = 41, Name = "RentFelxibility", Value = "Flexible" },
                new ListingFeature { Id = 42, Name = "RentFlexibility", Value = "Fixed-Period" },
                new ListingFeature { Id = 43, Name = "MinimumRentPeriod", Value = "6 months" },
                new ListingFeature { Id = 44, Name = "MinimumRentPeriod", Value = "12 months" },
                new ListingFeature { Id = 45, Name = "Facilities", Value = "Fridge" },
                new ListingFeature { Id = 46, Name = "Facilities", Value = "Microwave" },
                new ListingFeature { Id = 47, Name = "Facilities", Value = "Oven" },
                new ListingFeature { Id = 48, Name = "Facilities", Value = "Stove" },
                new ListingFeature { Id = 49, Name = "Facilities", Value = "Dishwasher" },
                new ListingFeature { Id = 50, Name = "Facilities", Value = "Coffe Maker" },
                new ListingFeature { Id = 51, Name = "Facilities", Value = "Toaster" },
                new ListingFeature { Id = 52, Name = "Facilities", Value = "Kettle" },
                new ListingFeature { Id = 53, Name = "Facilities", Value = "Washing Machine" },
                new ListingFeature { Id = 54, Name = "Facilities", Value = "Dryer" },
                new ListingFeature { Id = 55, Name = "Facilities", Value = "Iron" },
                new ListingFeature { Id = 56, Name = "Facilities", Value = "TV" },
                new ListingFeature { Id = 57, Name = "Facilities", Value = "Furniture" },
                new ListingFeature { Id = 58, Name = "Facilities", Value = "Intercom" },
                new ListingFeature { Id = 59, Name = "Facilities", Value = "Blinds" },
                new ListingFeature { Id = 60, Name = "Facilities", Value = "Internet" },
                new ListingFeature { Id = 61, Name = "Facilities", Value = "Metal Door" },
                new ListingFeature { Id = 62, Name = "Facilities", Value = "AC" },
                new ListingFeature { Id = 63, Name = "Facilities", Value = "Parking Space" },
                new ListingFeature { Id = 64, Name = "BuildingMaterial", Value = "Brick" },
                new ListingFeature { Id = 65, Name = "BuildingMaterial", Value = "BCA" },
                new ListingFeature { Id = 66, Name = "WindowsMaterial", Value = "Wood" },
                new ListingFeature { Id = 67, Name = "WindowsMaterial", Value = "Plastic" },
                new ListingFeature { Id = 68, Name = "Balcony", Value = "No" },
                new ListingFeature { Id = 69, Name = "Balcony", Value = "1" },
                new ListingFeature { Id = 70, Name = "Balcony", Value = "2" },
                new ListingFeature { Id = 71, Name = "Balcony", Value = "3" },
                new ListingFeature { Id = 72, Name = "Balcony", Value = "4" },
                new ListingFeature { Id = 73, Name = "AdditionalStorage", Value = "No" },
                new ListingFeature { Id = 74, Name = "AdditionalStorage", Value = "Basement" },
                new ListingFeature { Id = 75, Name = "AdditionalStorage", Value = "StorageRoom" }
            );

        }

        private void AddListingTypes(ModelBuilder modelBuilder)
        {
            var apartment = new ListingType { Id = 1, Name = "Apartament" };
            var microApartament = new ListingType { Id = 2, Name = "MicroApartament" };
            var single = new ListingType { Id = 3, Name = "Single" };
            var shared = new ListingType { Id = 4, Name = "Shared" };
        
            modelBuilder.Entity<ListingType>().HasData(apartment, microApartament, single, shared);
        }

        private void AddRentStatuses(ModelBuilder modelBuilder)
        {
            var active = new RentStatus { Id = 1, Name = "Active" };
            var inactive = new RentStatus { Id = 2, Name = "Inactive" };
            
            modelBuilder.Entity<RentStatus>().HasData(active, inactive);
        }

        private void AddUserFeatures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFeature>().HasData
            (
                new UserFeature { Id = 1, Name = "Gender", Value = "Male" },
                new UserFeature { Id = 2, Name = "Gender", Value = "Female" },
                new UserFeature { Id = 3, Name = "Gender", Value = "Other" },
                new UserFeature { Id = 4, Name = "Occupation", Value = "Part-Time Job" },
                new UserFeature { Id = 5, Name = "Occupation", Value = "Full-Time Job" },
                new UserFeature { Id = 6, Name = "Occupation", Value = "Student" },
                new UserFeature { Id = 7, Name = "YearOfStudy", Value = "1" },
                new UserFeature { Id = 8, Name = "YearOfStudy", Value = "2" },
                new UserFeature { Id = 9, Name = "YearOfStudy", Value = "3" },
                new UserFeature { Id = 10, Name = "YearOfStudy", Value = "4" },
                new UserFeature { Id = 11, Name = "YearOfStudy", Value = "5" },
                new UserFeature { Id = 12, Name = "YearOfStudy", Value = "6" },
                new UserFeature { Id = 13, Name = "ReligiousBeliefs", Value = "Orthodoxy" },
                new UserFeature { Id = 14, Name = "ReligiousBeliefs", Value = "Romano Catholicism" },
                new UserFeature { Id = 15, Name = "ReligiousBeliefs", Value = "Greek Catholicism" },
                new UserFeature { Id = 16, Name = "ReligiousBeliefs", Value = "Calvinist" },
                new UserFeature { Id = 17, Name = "ReligiousBeliefs", Value = "Lutheran" },
                new UserFeature { Id = 18, Name = "ReligiousBeliefs", Value = "Pentecostal Christian" },
                new UserFeature { Id = 19, Name = "ReligiousBeliefs", Value = "Islam" },
                new UserFeature { Id = 20, Name = "ReligiousBeliefs", Value = "Judaism" },
                new UserFeature { Id = 21, Name = "ReligiousBeliefs", Value = "Baptist" },
                new UserFeature { Id = 22, Name = "ReligiousBeliefs", Value = "Atheism/Agnosticism" },
                new UserFeature { Id = 23, Name = "ReligiousBeliefs", Value = "Adventist" },
                new UserFeature { Id = 24, Name = "ReligiousBeliefs", Value = "Jehovah’s Witnesses" },
                new UserFeature { Id = 25, Name = "ReligiousBeliefs", Value = "Buddhism" },
                new UserFeature { Id = 26, Name = "ReligiousBeliefs", Value = "Hindu" },
                new UserFeature { Id = 27, Name = "ReligiousBeliefs", Value = "Other" },
                new UserFeature { Id = 28, Name = "DietaryPreferences", Value = "No Preferences" },
                new UserFeature { Id = 29, Name = "DietaryPreferences", Value = "Vegetarian" },
                new UserFeature { Id = 30, Name = "DietaryPreferences", Value = "Vegan" },
                new UserFeature { Id = 31, Name = "DietaryPreferences", Value = "Pescatarian" },
                new UserFeature { Id = 32, Name = "DietaryPreferences", Value = "Gluten-Free" },
                new UserFeature { Id = 33, Name = "DietaryPreferences", Value = "Lactose-Free" },
                new UserFeature { Id = 34, Name = "DietaryPreferences", Value = "Keto" },
                new UserFeature { Id = 35, Name = "DietaryPreferences", Value = "Diabetic-Friendly" },
                new UserFeature { Id = 36, Name = "DietaryPreferences", Value = "Halal" },
                new UserFeature { Id = 37, Name = "DietaryPreferences", Value = "Kosher" },
                new UserFeature { Id = 38, Name = "DietaryPreferences", Value = "Organic" },
                new UserFeature { Id = 39, Name = "DietaryPreferences", Value = "Other" },
                new UserFeature { Id = 40, Name = "Allergies", Value = "No Allergies" },
                new UserFeature { Id = 41, Name = "Allergies", Value = "Peanuts/Nuts" },
                new UserFeature { Id = 42, Name = "Allergies", Value = "Dairy" },
                new UserFeature { Id = 43, Name = "Allergies", Value = "Eggs" },
                new UserFeature { Id = 44, Name = "Allergies", Value = "Wheat" },
                new UserFeature { Id = 45, Name = "Allergies", Value = "Soy" },
                new UserFeature { Id = 46, Name = "Allergies", Value = "Fish" },
                new UserFeature { Id = 47, Name = "Allergies", Value = "Pollen" },
                new UserFeature { Id = 48, Name = "Allergies", Value = "Dust Mites" },
                new UserFeature { Id = 49, Name = "Allergies", Value = "Mold" },
                new UserFeature { Id = 50, Name = "Allergies", Value = "Cats" },
                new UserFeature { Id = 51, Name = "Allergies", Value = "Dogs" },
                new UserFeature { Id = 52, Name = "Allergies", Value = "Latex" },
                new UserFeature { Id = 53, Name = "Allergies", Value = "Fragrances" },
                new UserFeature { Id = 54, Name = "Allergies", Value = "Cosmetic Products" },
                new UserFeature { Id = 55, Name = "Allergies", Value = "Detergents and Soaps" },
                new UserFeature { Id = 56, Name = "Allergies", Value = "Bee Stings" },
                new UserFeature { Id = 57, Name = "Allergies", Value = "Wasp Stings" },
                new UserFeature { Id = 58, Name = "Allergies", Value = "Ant Stings" },
                new UserFeature { Id = 59, Name = "Allergies", Value = "Medications" },
                new UserFeature { Id = 60, Name = "Allergies", Value = "Other" },
                new UserFeature { Id = 61, Name = "SleepingHours", Value = "Early Bird" },
                new UserFeature { Id = 62, Name = "SleepingHours", Value = "Night Owl" },
                new UserFeature { Id = 63, Name = "SleepingHours", Value = "Flexible" },
                new UserFeature { Id = 64, Name = "SleepingHours", Value = "Other" },
                new UserFeature { Id = 65, Name = "SmokingHabbits", Value = "Smoker" },
                new UserFeature { Id = 66, Name = "SmokingHabbits", Value = "Non-Smoker" },
                new UserFeature { Id = 67, Name = "SmokingHabbits", Value = "Doesn't Mind" },
                new UserFeature { Id = 68, Name = "AlcoholConsumption", Value = "Regular" },
                new UserFeature { Id = 69, Name = "AlcoholConsumption", Value = "Social" },
                new UserFeature { Id = 70, Name = "AlcoholConsumption", Value = "Rarely" },
                new UserFeature { Id = 71, Name = "AlcoholConsumption", Value = "Never" },
                new UserFeature { Id = 72, Name = "PetOwnership", Value = "No" },
                new UserFeature { Id = 73, Name = "PetOwnership", Value = "Cat" },
                new UserFeature { Id = 74, Name = "PetOwnership", Value = "Dog" },
                new UserFeature { Id = 75, Name = "PetOwnership", Value = "Bird" },
                new UserFeature { Id = 76, Name = "PetOwnership", Value = "Fish" },
                new UserFeature { Id = 77, Name = "PetOwnership", Value = "Rodent" },
                new UserFeature { Id = 78, Name = "PetOwnership", Value = "Other" },
                new UserFeature { Id = 79, Name = "PetPreferences", Value = "Likes Pets" },
                new UserFeature { Id = 80, Name = "PetPreferences", Value = "Doesn't Likes Pets" },
                new UserFeature { Id = 81, Name = "PetPreferences", Value = "Allergic" },
                new UserFeature { Id = 82, Name = "PetPreferences", Value = "No Preference" },
                new UserFeature { Id = 83, Name = "NoiseTolerance", Value = "Quiet" },
                new UserFeature { Id = 84, Name = "NoiseTolerance", Value = "Moderate" },
                new UserFeature { Id = 85, Name = "NoiseTolerance", Value = "Doesn't Mind" },
                new UserFeature { Id = 86, Name = "CleanlinessLevel", Value = "Very Clean" },
                new UserFeature { Id = 87, Name = "CleanlinessLevel", Value = "Moderate" },
                new UserFeature { Id = 88, Name = "CleanlinessLevel", Value = "Laid-Back" },
                new UserFeature { Id = 89, Name = "CookingHabbits", Value = "Loves Cooking" },
                new UserFeature { Id = 90, Name = "CookingHabbits", Value = "Cooks Occasionally" },
                new UserFeature { Id = 91, Name = "CookingHabbits", Value = "Doesn't Cook" },
                new UserFeature { Id = 92, Name = "PreferedLivingArrangement", Value = "Private Room" },
                new UserFeature { Id = 93, Name = "PreferedLivingArrangement", Value = "Shared Room" },
                new UserFeature { Id = 94, Name = "PreferedLivingArrangement", Value = "Doesn't Mind" },
                new UserFeature { Id = 95, Name = "Hobbies", Value = "Drawing" },
                new UserFeature { Id = 96, Name = "Hobbies", Value = "Painting" },
                new UserFeature { Id = 97, Name = "Hobbies", Value = "Singing" },
                new UserFeature { Id = 98, Name = "Hobbies", Value = "Calligraphy" },
                new UserFeature { Id = 99, Name = "Hobbies", Value = "Photography" },
                new UserFeature { Id = 100, Name = "Hobbies", Value = "Graphic Design" },
                new UserFeature { Id = 101, Name = "Hobbies", Value = "Playing an Instrument" },
                new UserFeature { Id = 102, Name = "Hobbies", Value = "Knitting/Crocheting" },
                new UserFeature { Id = 103, Name = "Hobbies", Value = "Sewing/Fashion Design" },
                new UserFeature { Id = 104, Name = "Hobbies", Value = "Dancing" },
                new UserFeature { Id = 105, Name = "Hobbies", Value = "Stand-up Comedy" },
                new UserFeature { Id = 106, Name = "Hobbies", Value = "Magic Tricks" },
                new UserFeature { Id = 107, Name = "Hobbies", Value = "Writing" },
                new UserFeature { Id = 108, Name = "Hobbies", Value = "Reading" },
                new UserFeature { Id = 109, Name = "Hobbies", Value = "Blogging" },
                new UserFeature { Id = 110, Name = "Hobbies", Value = "Running/Jogging" },
                new UserFeature { Id = 111, Name = "Hobbies", Value = "Yoga" },
                new UserFeature { Id = 112, Name = "Hobbies", Value = "Pilates" },
                new UserFeature { Id = 113, Name = "Hobbies", Value = "Swimming" },
                new UserFeature { Id = 114, Name = "Hobbies", Value = "Hiking" },
                new UserFeature { Id = 115, Name = "Hobbies", Value = "Cycling" },
                new UserFeature { Id = 116, Name = "Hobbies", Value = "Martial Arts" },
                new UserFeature { Id = 117, Name = "Hobbies", Value = "Football" },
                new UserFeature { Id = 118, Name = "Hobbies", Value = "Basketball" },
                new UserFeature { Id = 119, Name = "Hobbies", Value = "Volleyball" },
                new UserFeature { Id = 120, Name = "Hobbies", Value = "Handball" },
                new UserFeature { Id = 121, Name = "Hobbies", Value = "Rock Climbing" },
                new UserFeature { Id = 122, Name = "Hobbies", Value = "Gymnastics" },
                new UserFeature { Id = 123, Name = "Hobbies", Value = "Gaming" },
                new UserFeature { Id = 124, Name = "Hobbies", Value = "Programming/Coding" },
                new UserFeature { Id = 125, Name = "Hobbies", Value = "Robotics" },
                new UserFeature { Id = 126, Name = "Hobbies", Value = "VR" },
                new UserFeature { Id = 127, Name = "Hobbies", Value = "3D Printing" },
                new UserFeature { Id = 128, Name = "Hobbies", Value = "Drone Flying" },
                new UserFeature { Id = 129, Name = "Hobbies", Value = "Cooking" },
                new UserFeature { Id = 130, Name = "Hobbies", Value = "Baking" },
                new UserFeature { Id = 131, Name = "Hobbies", Value = "Coffee Brewing" },
                new UserFeature { Id = 132, Name = "Hobbies", Value = "Cake Decorating" },
                new UserFeature { Id = 133, Name = "Hobbies", Value = "Gardening" },
                new UserFeature { Id = 134, Name = "Hobbies", Value = "Bird Watching" },
                new UserFeature { Id = 135, Name = "Hobbies", Value = "Camping" },
                new UserFeature { Id = 136, Name = "Hobbies", Value = "Fishing" },
                new UserFeature { Id = 137, Name = "Hobbies", Value = "Geocaching" },
                new UserFeature { Id = 138, Name = "Hobbies", Value = "Stargazingg" },
                new UserFeature { Id = 139, Name = "Hobbies", Value = "Collecting Stamps" },
                new UserFeature { Id = 140, Name = "Hobbies", Value = "Coin Collecting" },
                new UserFeature { Id = 141, Name = "Hobbies", Value = "Collecting Action Figures" },
                new UserFeature { Id = 142, Name = "Hobbies", Value = "Vinyl Records Collecting" },
                new UserFeature { Id = 143, Name = "Hobbies", Value = "Fossil or Rock Collecting" },
                new UserFeature { Id = 144, Name = "Hobbies", Value = "Model Building" },
                new UserFeature { Id = 145, Name = "Hobbies", Value = "Origami" },
                new UserFeature { Id = 146, Name = "Hobbies", Value = "Beadwork" },
                new UserFeature { Id = 147, Name = "Hobbies", Value = "Puzzles" },
                new UserFeature { Id = 148, Name = "Hobbies", Value = "Chess" },
                new UserFeature { Id = 149, Name = "Hobbies", Value = "Sudoku" },
                new UserFeature { Id = 150, Name = "Hobbies", Value = "Traveling" },
                new UserFeature { Id = 151, Name = "Hobbies", Value = "Road Tripping" },
                new UserFeature { Id = 152, Name = "Hobbies", Value = "Backpacking" },
                new UserFeature { Id = 153, Name = "Hobbies", Value = "Movie Watching" },
                new UserFeature { Id = 154, Name = "Hobbies", Value = "Podcasting" },
                new UserFeature { Id = 155, Name = "Hobbies", Value = "Streaming/Content Creation" },
                new UserFeature { Id = 156, Name = "Hobbies", Value = "Astrology" },
                new UserFeature { Id = 157, Name = "Hobbies", Value = "Cosplaying" },
                new UserFeature { Id = 158, Name = "Hobbies", Value = "Parkour" },
                new UserFeature { Id = 159, Name = "Hobbies", Value = "Other" },
                new UserFeature { Id = 160, Name = "ExerciseRoutine", Value = "Gym Regular" },
                new UserFeature { Id = 161, Name = "ExerciseRoutine", Value = "Outdoor Activities" },
                new UserFeature { Id = 162, Name = "ExerciseRoutine", Value = "Doesn't Exercise Regularly" },
                new UserFeature { Id = 163, Name = "SocialHabbits", Value = "Outgoing" },
                new UserFeature { Id = 164, Name = "SocialHabbits", Value = "Introverted" },
                new UserFeature { Id = 165, Name = "SocialHabbits", Value = "Balanced" },
                new UserFeature { Id = 166, Name = "PrefferedRoommateGender", Value = "Same Gender" },
                new UserFeature { Id = 167, Name = "PrefferedRoommateGender", Value = "No Preference" },
                new UserFeature { Id = 168, Name = "GuestsTolerance", Value = "Frequent Visitors" },
                new UserFeature { Id = 169, Name = "GuestsTolerance", Value = "Rarely" },
                new UserFeature { Id = 170, Name = "GuestsTolerance", Value = "No Visitors" },
                new UserFeature { Id = 171, Name = "StudyEnvironment", Value = "Quiet" },
                new UserFeature { Id = 172, Name = "StudyEnvironment", Value = "Collaborative" },
                new UserFeature { Id = 173, Name = "StudyEnvironment", Value = "No Preference" },
                new UserFeature { Id = 174, Name = "PrefferedCommunicationMeans", Value = "Text" },
                new UserFeature { Id = 175, Name = "PrefferedCommunicationMeans", Value = "Calls" },
                new UserFeature { Id = 176, Name = "PrefferedCommunicationMeans", Value = "Face-to-face" },
                new UserFeature { Id = 177, Name = "PersonalityType", Value = "Intorvert" },
                new UserFeature { Id = 178, Name = "PersonalityType", Value = "Extrovert" },
                new UserFeature { Id = 179, Name = "ConflictResolutionStyle", Value = "Direct" },
                new UserFeature { Id = 180, Name = "ConflictResolutionStyle", Value = "Passive" },
                new UserFeature { Id = 181, Name = "ConflictResolutionStyle", Value = "Mediator" }
            );
        }

        private void AddNationalities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { Id = 1, Name = "Afghan" },
                new Nationality { Id = 2, Name = "Albanian" },
                new Nationality { Id = 3, Name = "Algerian" },
                new Nationality { Id = 4, Name = "American" },
                new Nationality { Id = 5, Name = "Andorran" },
                new Nationality { Id = 6, Name = "Angolan" },
                new Nationality { Id = 7, Name = "Antiguan" },
                new Nationality { Id = 8, Name = "Argentine" },
                new Nationality { Id = 9, Name = "Armenian" },
                new Nationality { Id = 10, Name = "Australian" },
                new Nationality { Id = 11, Name = "Austrian" },
                new Nationality { Id = 12, Name = "Azerbaijani" },
                new Nationality { Id = 13, Name = "Bahamian" },
                new Nationality { Id = 14, Name = "Bahraini" },
                new Nationality { Id = 15, Name = "Bangladeshi" },
                new Nationality { Id = 16, Name = "Barbadian" },
                new Nationality { Id = 17, Name = "Belarusian" },
                new Nationality { Id = 18, Name = "Belgian" },
                new Nationality { Id = 19, Name = "Belizean" },
                new Nationality { Id = 20, Name = "Beninese" },
                new Nationality { Id = 21, Name = "Bhutanese" },
                new Nationality { Id = 22, Name = "Bolivian" },
                new Nationality { Id = 23, Name = "Bosnian" },
                new Nationality { Id = 24, Name = "Botswanan" },
                new Nationality { Id = 25, Name = "Brazilian" },
                new Nationality { Id = 26, Name = "British" },
                new Nationality { Id = 27, Name = "Bruneian" },
                new Nationality { Id = 28, Name = "Bulgarian" },
                new Nationality { Id = 29, Name = "Burkinabe" },
                new Nationality { Id = 30, Name = "Burmese" },
                new Nationality { Id = 31, Name = "Burundian" },
                new Nationality { Id = 32, Name = "Cambodian" },
                new Nationality { Id = 33, Name = "Cameroonian" },
                new Nationality { Id = 34, Name = "Canadian" },
                new Nationality { Id = 35, Name = "Cape Verdean" },
                new Nationality { Id = 36, Name = "Central African" },
                new Nationality { Id = 37, Name = "Chadian" },
                new Nationality { Id = 38, Name = "Chilean" },
                new Nationality { Id = 39, Name = "Chinese" },
                new Nationality { Id = 40, Name = "Colombian" },
                new Nationality { Id = 41, Name = "Comorian" },
                new Nationality { Id = 42, Name = "Congolese (Congo-Brazzaville)" },
                new Nationality { Id = 43, Name = "Congolese (Congo-Kinshasa)" },
                new Nationality { Id = 44, Name = "Costa Rican" },
                new Nationality { Id = 45, Name = "Croatian" },
                new Nationality { Id = 46, Name = "Cuban" },
                new Nationality { Id = 47, Name = "Cypriot" },
                new Nationality { Id = 48, Name = "Czech" },
                new Nationality { Id = 49, Name = "Danish" },
                new Nationality { Id = 50, Name = "Djiboutian" },
                new Nationality { Id = 51, Name = "Dominican (Dominican Republic)" },
                new Nationality { Id = 52, Name = "Dominican (Dominica)" },
                new Nationality { Id = 53, Name = "Dutch" },
                new Nationality { Id = 54, Name = "East Timorese" },
                new Nationality { Id = 55, Name = "Ecuadorian" },
                new Nationality { Id = 56, Name = "Egyptian" },
                new Nationality { Id = 57, Name = "Emirati" },
                new Nationality { Id = 58, Name = "Equatorial Guinean" },
                new Nationality { Id = 59, Name = "Eritrean" },
                new Nationality { Id = 60, Name = "Estonian" },
                new Nationality { Id = 61, Name = "Eswatini (Swazi)" },
                new Nationality { Id = 62, Name = "Ethiopian" },
                new Nationality { Id = 63, Name = "Fijian" },
                new Nationality { Id = 64, Name = "Filipino" },
                new Nationality { Id = 65, Name = "Finnish" },
                new Nationality { Id = 66, Name = "French" },
                new Nationality { Id = 67, Name = "Gabonese" },
                new Nationality { Id = 68, Name = "Gambian" },
                new Nationality { Id = 69, Name = "Georgian" },
                new Nationality { Id = 70, Name = "German" },
                new Nationality { Id = 71, Name = "Ghanaian" },
                new Nationality { Id = 72, Name = "Greek" },
                new Nationality { Id = 73, Name = "Grenadian" },
                new Nationality { Id = 74, Name = "Guatemalan" },
                new Nationality { Id = 75, Name = "Guinean" },
                new Nationality { Id = 76, Name = "Guyanese" },
                new Nationality { Id = 77, Name = "Haitian" },
                new Nationality { Id = 78, Name = "Honduran" },
                new Nationality { Id = 79, Name = "Hungarian" },
                new Nationality { Id = 80, Name = "Icelander" },
                new Nationality { Id = 81, Name = "Indian" },
                new Nationality { Id = 82, Name = "Indonesian" },
                new Nationality { Id = 83, Name = "Iranian" },
                new Nationality { Id = 84, Name = "Iraqi" },
                new Nationality { Id = 85, Name = "Irish" },
                new Nationality { Id = 86, Name = "Israeli" },
                new Nationality { Id = 87, Name = "Italian" },
                new Nationality { Id = 88, Name = "Ivorian" },
                new Nationality { Id = 89, Name = "Jamaican" },
                new Nationality { Id = 90, Name = "Japanese" },
                new Nationality { Id = 91, Name = "Jordanian" },
                new Nationality { Id = 92, Name = "Kazakh" },
                new Nationality { Id = 93, Name = "Kenyan" },
                new Nationality { Id = 94, Name = "Kiribati" },
                new Nationality { Id = 95, Name = "Korean (North)" },
                new Nationality { Id = 96, Name = "Korean (South)" },
                new Nationality { Id = 97, Name = "Kosovar" },
                new Nationality { Id = 98, Name = "Kuwaiti" },
                new Nationality { Id = 99, Name = "Kyrgyz" },
                new Nationality { Id = 100, Name = "Lao" },
                new Nationality { Id = 101, Name = "Latvian" },
                new Nationality { Id = 102, Name = "Lebanese" },
                new Nationality { Id = 103, Name = "Liberian" },
                new Nationality { Id = 104, Name = "Libyan" },
                new Nationality { Id = 105, Name = "Liechtensteiner" },
                new Nationality { Id = 106, Name = "Lithuanian" },
                new Nationality { Id = 107, Name = "Luxembourger" },
                new Nationality { Id = 108, Name = "Madagascan" },
                new Nationality { Id = 109, Name = "Malawian" },
                new Nationality { Id = 110, Name = "Malaysian" },
                new Nationality { Id = 111, Name = "Maldivian" },
                new Nationality { Id = 112, Name = "Malian" },
                new Nationality { Id = 113, Name = "Maltese" },
                new Nationality { Id = 114, Name = "Marshallese" },
                new Nationality { Id = 115, Name = "Mauritanian" },
                new Nationality { Id = 116, Name = "Mauritian" },
                new Nationality { Id = 117, Name = "Mexican" },
                new Nationality { Id = 118, Name = "Micronesian" },
                new Nationality { Id = 119, Name = "Moldovan" },
                new Nationality { Id = 120, Name = "Monacan" },
                new Nationality { Id = 121, Name = "Mongolian" },
                new Nationality { Id = 122, Name = "Montenegrin" },
                new Nationality { Id = 123, Name = "Moroccan" },
                new Nationality { Id = 124, Name = "Mozambican" },
                new Nationality { Id = 125, Name = "Namibian" },
                new Nationality { Id = 126, Name = "Nauruan" },
                new Nationality { Id = 127, Name = "Nepalese" },
                new Nationality { Id = 128, Name = "New Zealander" },
                new Nationality { Id = 129, Name = "Nicaraguan" },
                new Nationality { Id = 130, Name = "Nigerien" },
                new Nationality { Id = 131, Name = "Nigerian" },
                new Nationality { Id = 132, Name = "Norwegian" },
                new Nationality { Id = 133, Name = "Omani" },
                new Nationality { Id = 134, Name = "Pakistani" },
                new Nationality { Id = 135, Name = "Palauan" },
                new Nationality { Id = 136, Name = "Palestinian" },
                new Nationality { Id = 137, Name = "Panamanian" },
                new Nationality { Id = 138, Name = "Papua New Guinean" },
                new Nationality { Id = 139, Name = "Paraguayan" },
                new Nationality { Id = 140, Name = "Peruvian" },
                new Nationality { Id = 141, Name = "Polish" },
                new Nationality { Id = 142, Name = "Portuguese" },
                new Nationality { Id = 143, Name = "Qatari" },
                new Nationality { Id = 144, Name = "Romanian" },
                new Nationality { Id = 145, Name = "Russian" },
                new Nationality { Id = 146, Name = "Rwandan" },
                new Nationality { Id = 147, Name = "Saint Lucian" },
                new Nationality { Id = 148, Name = "Salvadoran" },
                new Nationality { Id = 149, Name = "Samoan" },
                new Nationality { Id = 150, Name = "San Marinese" },
                new Nationality { Id = 151, Name = "Sao Tomean" },
                new Nationality { Id = 152, Name = "Saudi" },
                new Nationality { Id = 153, Name = "Senegalese" },
                new Nationality { Id = 154, Name = "Serbian" },
                new Nationality { Id = 155, Name = "Seychellois" },
                new Nationality { Id = 156, Name = "Sierra Leonean" },
                new Nationality { Id = 157, Name = "Singaporean" },
                new Nationality { Id = 158, Name = "Slovak" },
                new Nationality { Id = 159, Name = "Slovenian" },
                new Nationality { Id = 160, Name = "Solomon Islander" },
                new Nationality { Id = 161, Name = "Somali" },
                new Nationality { Id = 162, Name = "South African" },
                new Nationality { Id = 163, Name = "South Sudanese" },
                new Nationality { Id = 164, Name = "Spanish" },
                new Nationality { Id = 165, Name = "Sri Lankan" },
                new Nationality { Id = 166, Name = "Sudanese" },
                new Nationality { Id = 167, Name = "Surinamese" },
                new Nationality { Id = 168, Name = "Swedish" },
                new Nationality { Id = 169, Name = "Swiss" },
                new Nationality { Id = 170, Name = "Syrian" },
                new Nationality { Id = 171, Name = "Tajik" },
                new Nationality { Id = 172, Name = "Tanzanian" },
                new Nationality { Id = 173, Name = "Thai" },
                new Nationality { Id = 174, Name = "Togolese" },
                new Nationality { Id = 175, Name = "Tongan" },
                new Nationality { Id = 176, Name = "Trinidadian/Tobagonian" },
                new Nationality { Id = 177, Name = "Tunisian" },
                new Nationality { Id = 178, Name = "Turkish" },
                new Nationality { Id = 179, Name = "Turkmen" },
                new Nationality { Id = 180, Name = "Tuvaluan" },
                new Nationality { Id = 181, Name = "Ugandan" },
                new Nationality { Id = 182, Name = "Ukrainian" },
                new Nationality { Id = 183, Name = "Uruguayan" },
                new Nationality { Id = 184, Name = "Uzbek" },
                new Nationality { Id = 185, Name = "Vanuatuan" },
                new Nationality { Id = 186, Name = "Vatican" },
                new Nationality { Id = 187, Name = "Venezuelan" },
                new Nationality { Id = 188, Name = "Vietnamese" },
                new Nationality { Id = 189, Name = "Yemeni" },
                new Nationality { Id = 190, Name = "Zambian" },
                new Nationality { Id = 191, Name = "Zimbabwean" }
            );
        }
    }
}
