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
            services.AddScoped<IDocumentStorageRepository, DocumentStorageRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IFinancialHelpDocumentRepository, FinancialHelpDocumentRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IPropertyOwnerRepository, PropertyOwnerRepository>();
            services.AddScoped<IRentDocumentRepository, RentDocumentRepository>();
            services.AddScoped<IStoredPhotoRepository, StoredPhotoRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IDocumentStatusRepository, DocumentStatusRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IListingFeatureRepository, ListingFeatureRepository>();
            services.AddScoped<IListingTypeRepository, ListingTypeRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IRentStatusRepository, RentStatusRepository>();
            services.AddScoped<IUserFeatureRepository, UserFeatureRepository>();

            return services;
        }
    }
}
