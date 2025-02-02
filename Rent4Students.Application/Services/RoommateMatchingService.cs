using AutoMapper;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Repositories.Interfaces;

namespace Rent4Students.Application.Services
{
    public class RoommateMatchingService : IRoommateMatchingService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public RoommateMatchingService(
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseRoommateScoreDTO>> GetAllMatchingStudents(Guid id)
        {
            var students = await _studentRepository.GetAll();
            var currentStudent = students.FirstOrDefault(student => student.Id == id);

            return GetCompatibleRoommates(currentStudent, students);
        }

        public List<ResponseRoommateScoreDTO> GetCompatibleRoommates(Student currentStudent, List<Student> allStudents)
        {
            // Step 1: Filter out incompatible students
            var filteredStudents = allStudents
                .Where(s => s.Id != currentStudent.Id && // Exclude the current student
                    Math.Abs(s.Age - currentStudent.Age) <= 5 &&
                    FilterByPreferredGender(currentStudent, s) && // Match PreferredRoommateGender
                    FilterByPetCompatibility(currentStudent, s))
                .ToList();

            // Step 2: Calculate compatibility score
            var compatibilityScores = filteredStudents.Select(student => new
            {
                Student = student,
                Score = Math.Round(CalculateCompatibilityScore(currentStudent, student) * 3, 2)
            }).OrderByDescending(x => x.Score)
              .Where(student => student.Score > 5)
              .ToList();

            return compatibilityScores.Select(x => new ResponseRoommateScoreDTO { Student = _mapper.Map<ResponseStudentDTO>(x.Student), Score = x.Score}).ToList();
        }

        private bool FilterByPreferredGender(Student currentStudent, Student otherStudent)
        {
            var preferredGenderAttribute = currentStudent.Attributes?.FirstOrDefault(attr =>
                attr.Attribute.Name == "PrefferedRoommateGender");

            if (preferredGenderAttribute != null && preferredGenderAttribute.Attribute.Value == "Same Gender")
            {
                return currentStudent.GenderId == otherStudent.GenderId;
            }

            return true;
        }

        private bool FilterByPetCompatibility(Student currentStudent, Student otherStudent)
        {
            // Check current student's pet ownership
            var currentStudentPetOwnership = currentStudent.Attributes?.FirstOrDefault(attr => attr.Attribute.Name == "PetOwnership");
            var currentStudentOwnsPets = currentStudentPetOwnership != null && currentStudentPetOwnership.Attribute.Value != "No";

            // Check other student's pet ownership
            var otherStudentPetOwnership = otherStudent.Attributes?.FirstOrDefault(attr => attr.Attribute.Name == "PetOwnership");
            var otherStudentOwnsPets = otherStudentPetOwnership != null && otherStudentPetOwnership.Attribute.Value != "No";

            // Check allergies for both students
            var currentStudentPetAllergies = currentStudent.Allergies?.Any(allergy =>
                allergy.Allergy.Name == "Cats" ||
                allergy.Allergy.Name == "Dogs" ||
                allergy.Allergy.Name == "Birds" ||
                allergy.Allergy.Name == "Rodents" ||
                allergy.Allergy.Name == "Fish") ?? false;

            var otherStudentPetAllergies = otherStudent.Allergies?.Any(allergy =>
                allergy.Allergy.Name == "Cats" ||
                allergy.Allergy.Name == "Dogs" ||
                allergy.Allergy.Name == "Birds" ||
                allergy.Allergy.Name == "Rodents" ||
                allergy.Allergy.Name == "Fish") ?? false;

            // Incompatibility logic:
            // 1. If one student owns pets and the other is allergic, they are incompatible.
            if ((currentStudentOwnsPets && otherStudentPetAllergies) ||
                (otherStudentOwnsPets && currentStudentPetAllergies))
            {
                return false; // Incompatible
            }

            // 2. If both state they don't own pets, they are compatible.
            if ((currentStudentPetOwnership?.Attribute.Value == "No") &&
                (otherStudentPetOwnership?.Attribute.Value == "No"))
            {
                return true; // Compatible
            }

            // If no incompatibilities are found, assume they are compatible
            return true;
        }

        private double CalculateCompatibilityScore(Student currentStudent, Student otherStudent)
        {
            double score = 0;
            double maxScore = 0;

            // Matching hobbies (Jaccard Similarity)
            var commonHobbies = currentStudent.Hobbies.Select(hobby => hobby.HobbyId)?.Intersect(otherStudent.Hobbies.Select(hobby => hobby.HobbyId) ?? new List<int>()).Count() ?? 0;
            var totalHobbies = currentStudent.Hobbies.Select(hobby => hobby.HobbyId)?.Union(otherStudent.Hobbies.Select(hobby => hobby.HobbyId) ?? new List<int>()).Count() ?? 0;
            score += totalHobbies > 0 ? (double)commonHobbies / totalHobbies * 40 : 0; // 40% weight
            maxScore += 40;

            // Matching attributes
            var commonAttributes = currentStudent.Attributes.Select(attribute => attribute.AttributeId)?.Intersect(otherStudent.Attributes.Select(attribute => attribute.AttributeId) ?? new List<int>()).Count() ?? 0;
            score += commonAttributes * 3; // 3 points per matching attribute
            maxScore += 30; // Adjust based on average attribute count

            // Matching living preferences
            var commonPreferences = currentStudent.LivingPreferences.Select(preference => preference.ListingFeatureId)?.Intersect(otherStudent.LivingPreferences.Select(preference => preference.ListingFeatureId) ?? new List<int>()).Count() ?? 0;
            score += commonPreferences * 8; // 8 points per matching preference
            maxScore += 40;

            // Personality type match (if exists)
            var personalityMatch = currentStudent.Attributes?.FirstOrDefault(attr => attr.Attribute.Name == "PersonalityType");
            if (personalityMatch != null && otherStudent.Attributes?.Contains(personalityMatch) == true)
            {
                score += 15; // 15 points for personality match
                maxScore += 15;
            }

            // Allergy mismatches penalty
            var allergyMismatch = currentStudent.Allergies?.Any(allergy => otherStudent.Allergies?.Contains(allergy) == true) == false;
            if (allergyMismatch)
            {
                score -= 10; // Penalty for potential allergy conflicts
                maxScore += 10; // Include this in the normalization denominator
            }

            return maxScore > 0 ? Math.Max(0, score / maxScore * 100) : 0; // Ensure score is normalized and not negative
        }
    }
}
