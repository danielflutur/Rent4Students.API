using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Rent4Students.API.ServiceExtensions;
using Rent4Students.Application.Mappings;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Rent4Students.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDatabases(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddRepositories();
            builder.Services.AddServices();

            var corsSpecificOrigin = "AllowedOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsSpecificOrigin,
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.DocExpansion(DocExpansion.None);
                opt.EnableTryItOutByDefault();
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StoredPhotos")),
                RequestPath = "/StoredPhotos"
            });
            app.UseHttpsRedirection();

            app.UseCors(corsSpecificOrigin);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
