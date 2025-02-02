using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Rent4Students.Application.DTOs.FinancialHelpDocument;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.Student;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialHelpDocumentController : ControllerBase
    {
        private readonly IFinancialHelpDocumentService _documentService;

        public FinancialHelpDocumentController(IFinancialHelpDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FinancialHelpDocument), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadTemplate(IFormFile file, Guid facultyId)
        {
            var uploadedDocument = await _documentService.UploadTemplate(file, facultyId);

            return Ok(uploadedDocument.StorageURL);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseStudentDocumentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDocument(Guid id)
        {
            return Ok(await _documentService.GetDocument(id));
        }

        [HttpGet]
        [Route("download-template/")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFacultyTempalte(Guid facultyId, Guid studentId)
        {
            try
            {
                var filledPdfBytes = await _documentService.GetFacultyTemplate(facultyId, studentId);

                return File(filledPdfBytes, "application/pdf", "CompletedTemplate.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("student-documents/")]
        [ProducesResponseType(typeof(FinancialHelpDocument), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadRentDocuments(IFormFile file,[FromForm] Guid studentId)
        {
            var uploadedDocument = await _documentService.UploadRentDocuments(file, studentId);

            return Ok(uploadedDocument.StorageURL);
        }

        [HttpGet]
        [Route("faculty/{id}")]
        [ProducesResponseType(typeof(ResponseStudentDocumentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllFaculty(Guid id)
        {
            return Ok(await _documentService.GetAllFaculty(id));
        }

        [HttpGet]
        [Route("student/{id}")]
        [ProducesResponseType(typeof(ResponseStudentDocumentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllForStudent(Guid id)
        {
            return Ok(await _documentService.GetAllForStudent(id));
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseStudentDocumentDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDocs()
        {
            return Ok(await _documentService.GetAllDocs());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _documentService.Delete(id);

            return Ok(id);
        }
    }
}
