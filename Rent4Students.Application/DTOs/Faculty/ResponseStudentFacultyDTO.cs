using Rent4Students.Application.DTOs.University;

namespace Rent4Students.Application.DTOs.Faculty
{
    public class ResponseStudentFacultyDTO
    {
        public string Name { get; set; }
        public ResponseStudentUniversityDTO University { get; set; }
    }
}
