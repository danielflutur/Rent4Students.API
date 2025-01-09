using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.ListingFeature;
using Rent4Students.Application.Services.Interfaces.Enums;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingFeatureController : ControllerBase
    {
        private readonly IListingFeatureService _featureService;

        public ListingFeatureController(IListingFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseListingFeatureDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _featureService.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseListingFeatureDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _featureService.GetAll());
        }

        [HttpGet]
        [Route("ids/")]
        [ProducesResponseType(typeof(List<ResponseListingFeatureDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIds([FromQuery] List<int> id)
        {
            var features = await _featureService.GetByIds(id);

            return features.Any() ? Ok(features) : NoContent();
        }

    }
}
