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
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<DocumentStatus> DocumentStatus { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
        public DbSet<ListingFeature> ListingFeature { get; set; }
        public DbSet<ListingType> ListingType { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<PersonalityAttribute> PersonalityAttribute { get; set; }
        public DbSet<RentStatus> RentStatus { get; set; }
        public DbSet<LivingAmenity> LivingAmenity { get; set; }
        public DbSet<LivingPreference> LivingPreference { get; set; }
        public DbSet<RentHistory> RentHistory { get; set; }
        public DbSet<StudentAllergies> StudentAllergies{ get; set; }
        public DbSet<StudentAttributes> StudentAttributes { get; set; }
        public DbSet<StudentHobbies> StudentHobbies { get; set; }
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
            new AgencyConfiguration().Configure(modelBuilder.Entity<Agency>());
            new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
            new AllergyConfiguration().Configure(modelBuilder.Entity<Allergy>());
            new DocumentStatusConfiguration().Configure(modelBuilder.Entity<DocumentStatus>());
            new DocumentTypeConfiguration().Configure(modelBuilder.Entity<DocumentType>());
            new GenderConfiguration().Configure(modelBuilder.Entity<Gender>());
            new HobbyConfiguration().Configure(modelBuilder.Entity<Hobby>());
            new ListingFeatureConfiguration().Configure(modelBuilder.Entity<ListingFeature>());
            new ListingTypeConfiguration().Configure(modelBuilder.Entity<ListingType>());
            new NationalityConfiguration().Configure(modelBuilder.Entity<Nationality>());
            new PersonalityAttributeConfiguration().Configure(modelBuilder.Entity<PersonalityAttribute>());
            new RentStatusConfiguration().Configure(modelBuilder.Entity<RentStatus>());
            new LivingAmenityConfiguration().Configure(modelBuilder.Entity<LivingAmenity>());
            new LivingPreferenceConfiguration().Configure(modelBuilder.Entity<LivingPreference>());
            new RentHistoryConfiguration().Configure(modelBuilder.Entity<RentHistory>());
            new StudentAllergiesConfiguration().Configure(modelBuilder.Entity<StudentAllergies>());
            new StudentAttributesConfiguration().Configure(modelBuilder.Entity<StudentAttributes>());
            new StudentHobbiesConfiguration().Configure(modelBuilder.Entity<StudentHobbies>());
            new StudentRoommateConfiguration().Configure(modelBuilder.Entity<StudentRoommate>());

            AddDefaultEnums(modelBuilder);
        }

        private void AddDefaultEnums(ModelBuilder modelBuilder)
        {
            AddAllergies(modelBuilder);
            AddDocumentStatuses(modelBuilder);
            AddDocumentTypes(modelBuilder);
            AddGenders(modelBuilder);
            AddHobbies(modelBuilder);
            AddListingFeatures(modelBuilder);
            AddListingTypes(modelBuilder);
            AddNationalities(modelBuilder);
            AddPersonalityAttributes(modelBuilder);
            AddRentStatuses(modelBuilder);
        }

        private void AddAllergies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>().HasData
            (
                new Allergy { Id = 1, Name = "No Allergies" },
                new Allergy { Id = 2, Name = "Peanuts/Nuts" },
                new Allergy { Id = 3, Name = "Dairy" },
                new Allergy { Id = 4, Name = "Eggs" },
                new Allergy { Id = 5, Name = "Wheat" },
                new Allergy { Id = 6, Name = "Soy" },
                new Allergy { Id = 7, Name = "Fish" },
                new Allergy { Id = 8, Name = "Pollen" },
                new Allergy { Id = 9, Name = "Dust Mites" },
                new Allergy { Id = 10, Name = "Mold" },
                new Allergy { Id = 11, Name = "Cats" },
                new Allergy { Id = 12, Name = "Dogs" },
                new Allergy { Id = 13, Name = "Latex" },
                new Allergy { Id = 14, Name = "Fragrances" },
                new Allergy { Id = 15, Name = "Cosmetic Products" },
                new Allergy { Id = 16, Name = "Detergents and Soaps" },
                new Allergy { Id = 17, Name = "Bee Stings" },
                new Allergy { Id = 18, Name = "Wasp Stings" },
                new Allergy { Id = 19, Name = "Ant Stings" },
                new Allergy { Id = 20, Name = "Medications" },
                new Allergy { Id = 21, Name = "Other" }
            );
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
            var rentTemplate = new DocumentType { Id = 3, Name = "RentContractTemplate" };
            var financialTemplate = new DocumentType { Id = 4, Name = "FinancialHelpTemplate" };
            
            modelBuilder.Entity<DocumentType>().HasData(rentContract, financialHelp); 
        }
       
        private void AddGenders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData
            (
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" },
                new Gender { Id = 3, Name = "Other" }
            );
        }

        private void AddHobbies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Painting" },
                new Hobby { Id = 2, Name = "Singing" },
                new Hobby { Id = 3, Name = "Calligraphy" },
                new Hobby { Id = 4, Name = "Photography" },
                new Hobby { Id = 5, Name = "Graphic Design" },
                new Hobby { Id = 6, Name = "Playing an Instrument" },
                new Hobby { Id = 7, Name = "Knitting/Crocheting" },
                new Hobby { Id = 8, Name = "Sewing/Fashion Design" },
                new Hobby { Id = 9, Name = "Dancing" },
                new Hobby { Id = 10, Name = "Stand-up Comedy" },
                new Hobby { Id = 11, Name = "Magic Tricks" },
                new Hobby { Id = 12, Name = "Writing" },
                new Hobby { Id = 13, Name = "Reading" },
                new Hobby { Id = 14, Name = "Blogging" },
                new Hobby { Id = 15, Name = "Running/Jogging" },
                new Hobby { Id = 16, Name = "Yoga" },
                new Hobby { Id = 17, Name = "Pilates" },
                new Hobby { Id = 18, Name = "Swimming" },
                new Hobby { Id = 19, Name = "Hiking" },
                new Hobby { Id = 20, Name = "Cycling" },
                new Hobby { Id = 21, Name = "Martial Arts" },
                new Hobby { Id = 22, Name = "Football" },
                new Hobby { Id = 23, Name = "Basketball" },
                new Hobby { Id = 24, Name = "Volleyball" },
                new Hobby { Id = 25, Name = "Handball" },
                new Hobby { Id = 26, Name = "Rock Climbing" },
                new Hobby { Id = 27, Name = "Gymnastics" },
                new Hobby { Id = 28, Name = "Gaming" },
                new Hobby { Id = 29, Name = "Programming/Coding" },
                new Hobby { Id = 30, Name = "Drawing" },
                new Hobby { Id = 31, Name = "Robotics" },
                new Hobby { Id = 32, Name = "VR" },
                new Hobby { Id = 33, Name = "3D Printing" },
                new Hobby { Id = 34, Name = "Drone Flying" },
                new Hobby { Id = 35, Name = "Cooking" },
                new Hobby { Id = 36, Name = "Baking" },
                new Hobby { Id = 37, Name = "Coffee Brewing" },
                new Hobby { Id = 38, Name = "Cake Decorating" },
                new Hobby { Id = 39, Name = "Gardening" },
                new Hobby { Id = 40, Name = "Bird Watching" },
                new Hobby { Id = 41, Name = "Camping" },
                new Hobby { Id = 42, Name = "Fishing" },
                new Hobby { Id = 43, Name = "Geocaching" },
                new Hobby { Id = 44, Name = "Stargazingg" },
                new Hobby { Id = 45, Name = "Collecting Stamps" },
                new Hobby { Id = 46, Name = "Coin Collecting" },
                new Hobby { Id = 47, Name = "Collecting Action Figures" },
                new Hobby { Id = 48, Name = "Vinyl Records Collecting" },
                new Hobby { Id = 49, Name = "Fossil or Rock Collecting" },
                new Hobby { Id = 50, Name = "Model Building" },
                new Hobby { Id = 51, Name = "Origami" },
                new Hobby { Id = 52, Name = "Beadwork" },
                new Hobby { Id = 53, Name = "Puzzles" },
                new Hobby { Id = 54, Name = "Chess" },
                new Hobby { Id = 55, Name = "Sudoku" },
                new Hobby { Id = 56, Name = "Traveling" },
                new Hobby { Id = 57, Name = "Road Tripping" },
                new Hobby { Id = 58, Name = "Backpacking" },
                new Hobby { Id = 59, Name = "Movie Watching" },
                new Hobby { Id = 60, Name = "Podcasting" },
                new Hobby { Id = 61, Name = "Streaming/Content Creation" },
                new Hobby { Id = 62, Name = "Astrology" },
                new Hobby { Id = 63, Name = "Cosplaying" },
                new Hobby { Id = 64, Name = "Parkour" },
                new Hobby { Id = 65, Name = "Other" }
                );
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

        private void AddPersonalityAttributes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalityAttribute>().HasData
            (
                new PersonalityAttribute { Id = 1, Name = "Occupation", Value = "Part-Time Job" },
                new PersonalityAttribute { Id = 2, Name = "Occupation", Value = "Full-Time Job" },
                new PersonalityAttribute { Id = 3, Name = "Occupation", Value = "Student" },
                new PersonalityAttribute { Id = 4, Name = "ReligiousBeliefs", Value = "Orthodoxy" },
                new PersonalityAttribute { Id = 5, Name = "ReligiousBeliefs", Value = "Romano Catholicism" },
                new PersonalityAttribute { Id = 6, Name = "ReligiousBeliefs", Value = "Greek Catholicism" },
                new PersonalityAttribute { Id = 7, Name = "ReligiousBeliefs", Value = "Calvinist" },
                new PersonalityAttribute { Id = 8, Name = "ReligiousBeliefs", Value = "Lutheran" },
                new PersonalityAttribute { Id = 9, Name = "ReligiousBeliefs", Value = "Pentecostal Christian" },
                new PersonalityAttribute { Id = 10, Name = "ReligiousBeliefs", Value = "Islam" },
                new PersonalityAttribute { Id = 11, Name = "ReligiousBeliefs", Value = "Judaism" },
                new PersonalityAttribute { Id = 12, Name = "ReligiousBeliefs", Value = "Baptist" },
                new PersonalityAttribute { Id = 13, Name = "ReligiousBeliefs", Value = "Atheism/Agnosticism" },
                new PersonalityAttribute { Id = 14, Name = "ReligiousBeliefs", Value = "Adventist" },
                new PersonalityAttribute { Id = 15, Name = "ReligiousBeliefs", Value = "Jehovah’s Witnesses" },
                new PersonalityAttribute { Id = 16, Name = "ReligiousBeliefs", Value = "Buddhism" },
                new PersonalityAttribute { Id = 17, Name = "ReligiousBeliefs", Value = "Hindu" },
                new PersonalityAttribute { Id = 18, Name = "ReligiousBeliefs", Value = "Other" },
                new PersonalityAttribute { Id = 19, Name = "DietaryPreferences", Value = "No Preferences" },
                new PersonalityAttribute { Id = 20, Name = "DietaryPreferences", Value = "Vegetarian" },
                new PersonalityAttribute { Id = 21, Name = "DietaryPreferences", Value = "Vegan" },
                new PersonalityAttribute { Id = 22, Name = "DietaryPreferences", Value = "Pescatarian" },
                new PersonalityAttribute { Id = 23, Name = "DietaryPreferences", Value = "Gluten-Free" },
                new PersonalityAttribute { Id = 24, Name = "DietaryPreferences", Value = "Lactose-Free" },
                new PersonalityAttribute { Id = 25, Name = "DietaryPreferences", Value = "Keto" },
                new PersonalityAttribute { Id = 26, Name = "DietaryPreferences", Value = "Diabetic-Friendly" },
                new PersonalityAttribute { Id = 27, Name = "DietaryPreferences", Value = "Halal" },
                new PersonalityAttribute { Id = 28, Name = "DietaryPreferences", Value = "Kosher" },
                new PersonalityAttribute { Id = 29, Name = "DietaryPreferences", Value = "Organic" },
                new PersonalityAttribute { Id = 30, Name = "DietaryPreferences", Value = "Other" },
                new PersonalityAttribute { Id = 31, Name = "SleepingHours", Value = "Early Bird" },
                new PersonalityAttribute { Id = 32, Name = "SleepingHours", Value = "Night Owl" },
                new PersonalityAttribute { Id = 33, Name = "SleepingHours", Value = "Flexible" },
                new PersonalityAttribute { Id = 34, Name = "SleepingHours", Value = "Other" },
                new PersonalityAttribute { Id = 35, Name = "SmokingHabbits", Value = "Smoker" },
                new PersonalityAttribute { Id = 36, Name = "SmokingHabbits", Value = "Non-Smoker" },
                new PersonalityAttribute { Id = 37, Name = "SmokingHabbits", Value = "Doesn't Mind" },
                new PersonalityAttribute { Id = 38, Name = "AlcoholConsumption", Value = "Regular" },
                new PersonalityAttribute { Id = 39, Name = "AlcoholConsumption", Value = "Social" },
                new PersonalityAttribute { Id = 40, Name = "AlcoholConsumption", Value = "Rarely" },
                new PersonalityAttribute { Id = 41, Name = "AlcoholConsumption", Value = "Never" },
                new PersonalityAttribute { Id = 42, Name = "PetOwnership", Value = "No" },
                new PersonalityAttribute { Id = 43, Name = "PetOwnership", Value = "Cat" },
                new PersonalityAttribute { Id = 44, Name = "PetOwnership", Value = "Dog" },
                new PersonalityAttribute { Id = 45, Name = "PetOwnership", Value = "Bird" },
                new PersonalityAttribute { Id = 46, Name = "PetOwnership", Value = "Fish" },
                new PersonalityAttribute { Id = 47, Name = "PetOwnership", Value = "Rodent" },
                new PersonalityAttribute { Id = 48, Name = "PetOwnership", Value = "Other" },
                new PersonalityAttribute { Id = 49, Name = "PetPreferences", Value = "Likes Pets" },
                new PersonalityAttribute { Id = 50, Name = "PetPreferences", Value = "Doesn't Likes Pets" },
                new PersonalityAttribute { Id = 51, Name = "PetPreferences", Value = "Allergic" },
                new PersonalityAttribute { Id = 52, Name = "PetPreferences", Value = "No Preference" },
                new PersonalityAttribute { Id = 53, Name = "NoiseTolerance", Value = "Quiet" },
                new PersonalityAttribute { Id = 54, Name = "NoiseTolerance", Value = "Moderate" },
                new PersonalityAttribute { Id = 55, Name = "NoiseTolerance", Value = "Doesn't Mind" },
                new PersonalityAttribute { Id = 56, Name = "CleanlinessLevel", Value = "Very Clean" },
                new PersonalityAttribute { Id = 57, Name = "CleanlinessLevel", Value = "Moderate" },
                new PersonalityAttribute { Id = 58, Name = "CleanlinessLevel", Value = "Laid-Back" },
                new PersonalityAttribute { Id = 59, Name = "CookingHabbits", Value = "Loves Cooking" },
                new PersonalityAttribute { Id = 60, Name = "CookingHabbits", Value = "Cooks Occasionally" },
                new PersonalityAttribute { Id = 61, Name = "CookingHabbits", Value = "Doesn't Cook" },
                new PersonalityAttribute { Id = 62, Name = "PreferedLivingArrangement", Value = "Private Room" },
                new PersonalityAttribute { Id = 63, Name = "PreferedLivingArrangement", Value = "Shared Room" },
                new PersonalityAttribute { Id = 64, Name = "PreferedLivingArrangement", Value = "Doesn't Mind" },
                new PersonalityAttribute { Id = 65, Name = "ExerciseRoutine", Value = "Gym Regular" },
                new PersonalityAttribute { Id = 66, Name = "ExerciseRoutine", Value = "Outdoor Activities" },
                new PersonalityAttribute { Id = 67, Name = "ExerciseRoutine", Value = "Doesn't Exercise Regularly" },
                new PersonalityAttribute { Id = 68, Name = "SocialHabbits", Value = "Outgoing" },
                new PersonalityAttribute { Id = 69, Name = "SocialHabbits", Value = "Introverted" },
                new PersonalityAttribute { Id = 70, Name = "SocialHabbits", Value = "Balanced" },
                new PersonalityAttribute { Id = 71, Name = "PrefferedRoommateGender", Value = "Same Gender" },
                new PersonalityAttribute { Id = 72, Name = "PrefferedRoommateGender", Value = "No Preference" },
                new PersonalityAttribute { Id = 73, Name = "GuestsTolerance", Value = "Frequent Visitors" },
                new PersonalityAttribute { Id = 74, Name = "GuestsTolerance", Value = "Rarely" },
                new PersonalityAttribute { Id = 75, Name = "GuestsTolerance", Value = "No Visitors" },
                new PersonalityAttribute { Id = 76, Name = "StudyEnvironment", Value = "Quiet" },
                new PersonalityAttribute { Id = 77, Name = "StudyEnvironment", Value = "Collaborative" },
                new PersonalityAttribute { Id = 78, Name = "StudyEnvironment", Value = "No Preference" },
                new PersonalityAttribute { Id = 79, Name = "PrefferedCommunicationMeans", Value = "Text" },
                new PersonalityAttribute { Id = 80, Name = "PrefferedCommunicationMeans", Value = "Calls" },
                new PersonalityAttribute { Id = 81, Name = "PrefferedCommunicationMeans", Value = "Face-to-face" },
                new PersonalityAttribute { Id = 82, Name = "PersonalityType", Value = "Intorvert" },
                new PersonalityAttribute { Id = 83, Name = "PersonalityType", Value = "Extrovert" },
                new PersonalityAttribute { Id = 84, Name = "ConflictResolutionStyle", Value = "Direct" },
                new PersonalityAttribute { Id = 85, Name = "ConflictResolutionStyle", Value = "Passive" },
                new PersonalityAttribute { Id = 86, Name = "ConflictResolutionStyle", Value = "Mediator" }
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
