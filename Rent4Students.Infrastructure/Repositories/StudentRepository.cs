using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;
using Rent4Students.Infrastructure.Repositories.Base;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<Student> GetById(Guid id)
        {

            return await _context.Student
                .Where(student => student.Id == id)
                .Include(student => student.Gender)
                .Include(student => student.Nationality)
                .Include(student => student.FacultyName)
                .Include(student => student.ProfilePhoto)
                .Include(student => student.Address)
                .Include(student => student.Hobbies)
                    .ThenInclude(hobby => hobby.Hobby)
                .Include(student => student.Allergies)
                    .ThenInclude(allergy => allergy.Allergy)
                .Include(student => student.Attributes)
                    .ThenInclude(attribute => attribute.Attribute)
                .Include(student => student.LivingPreferences)
                    .ThenInclude(preference => preference.ListingFeature)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Student>> GetAll()
        {
            return await _context.Student
                .Where(student => student.IsDeleted == false)
                .Include(student => student.Gender)
                .Include(student => student.Nationality)
                .Include(student => student.FacultyName)
                .Include(student => student.FacultyName.ParentUniversity)
                .Include(student => student.ProfilePhoto)
                .Include(student => student.Address)
                .Include(student => student.Hobbies)
                    .ThenInclude(hobby => hobby.Hobby)
                .Include(student => student.Allergies)
                    .ThenInclude(allergy => allergy.Allergy)
                .Include(student => student.Attributes)
                    .ThenInclude(attribute => attribute.Attribute)
                .Include(student => student.LivingPreferences)
                    .ThenInclude(preference => preference.ListingFeature)
                .ToListAsync();
                
        }
    }
}
