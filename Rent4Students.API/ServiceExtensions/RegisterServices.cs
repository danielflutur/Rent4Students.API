using Rent4Students.Application.Services;
using Rent4Students.Application.Services.Enums;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Application.Services.Interfaces.Enums;

namespace Rent4Students.API.ServiceExtensions
{
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IListingService, LisitngService>();
            services.AddScoped<IPropertyOwnerService, PropertyOwnerService>();
            services.AddScoped<IStoredPhotoService, StoredPhotoService>();
            services.AddScoped<IListingFeatureService, ListingFeatureService>();

            return services;
        }
    }
}
