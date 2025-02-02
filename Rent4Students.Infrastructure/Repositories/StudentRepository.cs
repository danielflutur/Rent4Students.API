using Microsoft.EntityFrameworkCore;
using Rent4Students.Domain.Entities;
using Rent4Students.Domain.Entities.Enums;
using Rent4Students.Domain.Entities.Joined;
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

        public async Task<Student> UpdateStudentDetails(Student entity, List<Hobby> hobbies, List<PersonalityAttribute> attributes, List<Allergy> allergies)
        {
            var existingHobbies = _context.StudentHobbies.Where(hobbies => hobbies.StudentId == entity.Id).ToList();
            var existingAllergies = _context.StudentAllergies.Where(allergies => allergies.StudentId == entity.Id).ToList();
            var existingAttributess = _context.StudentAttributes.Where(attributes => attributes.StudentId == entity.Id).ToList();

            _context.StudentHobbies.RemoveRange(existingHobbies);
            _context.StudentAllergies.RemoveRange(existingAllergies);
            _context.StudentAttributes.RemoveRange(existingAttributess);

            entity.Hobbies = hobbies
                .Select(hobby => new StudentHobbies
                {
                    Student = entity,
                    StudentId = entity.Id,
                    Hobby = hobby,
                    HobbyId = hobby.Id
                })
                .ToList();

            entity.Allergies = allergies
                .Select(allergy => new StudentAllergies
                {
                    Student = entity,
                    StudentId = entity.Id,
                    Allergy = allergy,
                    AllergyId = allergy.Id,
                })
                .ToList();

            entity.Attributes = attributes
                .Select(attribute => new StudentAttributes
                {
                    Student = entity,
                    StudentId = entity.Id,
                    Attribute = attribute,
                    AttributeId = attribute.Id,
                })
                .ToList();

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Student> GetByEmail(string email)
        {
            return await _context.Student
                .Where(student => student.Email == email)
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
    }
}
