using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IRoommateMatchingService _matchingService;

        public StudentsController(
            IStudentService studentService, 
            IRoommateMatchingService matchingService)
        {
            _studentService = studentService;
            _matchingService = matchingService;
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ResponseStudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(StudentDTO studentDTO)
        {
            return Ok(await _studentService.Create(studentDTO));
        }

        [HttpPost]
        [Route("addPhoto")]
        [ProducesResponseType(typeof(ResponseStudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProfilePhoto(IFormFile profilePhoto, Guid id)
        {
            return Ok(await _studentService.AddProfilePhoto(profilePhoto, id));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _studentService.GetById(id));
        }

        [HttpGet]
        [Route("matching/{id}")]
        [ProducesResponseType(typeof(List<ResponseStudentDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMatching(Guid id)
        {
            return Ok(await _matchingService.GetAllMatchingStudents(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseStudentDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, UpdateStudentDTO studentDTO)
        {
            return Ok(await _studentService.Update(id, studentDTO));
        }

        [HttpPut("update-details/{id}")]
        [ProducesResponseType(typeof(ResponseStudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStudentDetails(Guid id, StudentDetailsDTO studentDTO)
        {
            return Ok(await _studentService.UpdateStudentDetails(id, studentDTO));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _studentService.Delete(id);

            return Ok(id);
        }
    }
}
