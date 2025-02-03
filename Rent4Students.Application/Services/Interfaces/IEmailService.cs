using Rent4Students.Domain.Entities;

namespace Rent4Students.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendAccessEmailForFaculty(Faculty faculty);
    }
}
