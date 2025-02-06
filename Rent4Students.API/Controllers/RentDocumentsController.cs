using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentDocumentsController : ControllerBase
    {
        private readonly IRentDocumentService _documentService;

        public RentDocumentsController(IRentDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RentDocument), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadContract(IFormFile file, Guid listingId)
        {
            var uploadedDocument = await _documentService.UploadRentContract(file, listingId);

            return Ok(uploadedDocument.StorageURL);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetContract(Guid id)
        {
            try
            {
                var filledPdfBytes = await _documentService.GetRentContract(id);

                return File(filledPdfBytes, "application/pdf", "CompletedTemplate.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
