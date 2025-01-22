using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.DTOs.ListingFeature;
using Rent4Students.Application.Services.Interfaces;

[ApiController]
[Route("api/detect-appliances")]
public class DetectionController : ControllerBase
{
    private readonly IObjectDetectionService _detectionService;

    public DetectionController(IObjectDetectionService detectionService)
    {
        _detectionService = detectionService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(List<ResponseListingFeatureDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DetectAppliances(IFormFile image)
    {
        if (image == null || image.Length == 0)
        {
            return BadRequest("No image provided.");
        }

        using var memoryStream = new MemoryStream();
        image.CopyTo(memoryStream);
        var detectedObjects = await _detectionService.DetectObjects(memoryStream.ToArray());

        return detectedObjects.Any() ?Ok(detectedObjects) : NoContent();
    }
}
