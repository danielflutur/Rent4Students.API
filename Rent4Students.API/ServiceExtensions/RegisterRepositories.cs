using Rent4Students.Infrastructure.Repositories;
using Rent4Students.Infrastructure.Repositories.Enums;
using Rent4Students.Infrastructure.Repositories.Interfaces;
using Rent4Students.Infrastructure.Repositories.Interfaces.Enums;

namespace Rent4Students.API.ServiceExtensions
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IFinancialHelpDocumentRepository, FinancialHelpDocumentRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IPropertyOwnerRepository, PropertyOwnerRepository>();
            services.AddScoped<IRentDocumentRepository, RentDocumentRepository>();
            services.AddScoped<IStoredPhotoRepository, StoredPhotoRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<IDocumentStatusRepository, DocumentStatusRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IHobbyRepository, HobbyRepository>();
            services.AddScoped<IListingFeatureRepository, ListingFeatureRepository>();
            services.AddScoped<IListingTypeRepository, ListingTypeRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IPersonalityAttributeRepository, PersonalityAttributeRepository>();
            services.AddScoped<IRentStatusRepository, RentStatusRepository>();

            return services;
        }
    }
}
