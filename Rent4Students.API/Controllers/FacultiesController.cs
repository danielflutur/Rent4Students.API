using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.DTOs.Faculty;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // POST: api/Faculties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ResponseFacultyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFaculty(FacultyDTO facultyDTO)
        {
            return Ok(await _facultyService.Create(facultyDTO));
        }

        [HttpPost]
        [Route("addPhoto")]
        [ProducesResponseType(typeof(ResponseStudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProfilePhoto(IFormFile profilePhoto, Guid id)
        {
            return Ok(await _facultyService.AddProfilePhoto(profilePhoto, id));
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseFacultyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _facultyService.GetById(id));
        }

        [HttpGet]
        [Route("allByUniversity/{id}")]
        [ProducesResponseType(typeof(ResponseFacultyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllByUniversityId(Guid id)
        {
            return Ok(await _facultyService.GetAllByUniversityId(id));
        }

        [HttpGet]
        [Route("sendEmail/{facultyId}")]
        [ProducesResponseType(typeof(ResponseFacultyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendFacultyEmail(Guid facultyId)
        {
            return Ok(await _facultyService.SendFacultyEmail(facultyId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseFacultyDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _facultyService.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseFacultyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, UpdateFacultyDTO facultyDTO)
        {
            return Ok(await _facultyService.Update(id, facultyDTO));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _facultyService.Delete(id);

            return Ok(id);
        }
    }
}
