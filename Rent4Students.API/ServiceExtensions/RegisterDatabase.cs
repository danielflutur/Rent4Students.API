using Microsoft.EntityFrameworkCore;
using Rent4Students.Infrastructure.Data;

namespace Rent4Students.API.ServiceExtensions
{
    public static class RegisterDatabase
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationConnectionString = configuration.GetConnectionString("ApplicationConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationConnectionString, b => b.MigrationsAssembly("Rent4Students.Infrastructure")));

            return services;
        }
    }
}
