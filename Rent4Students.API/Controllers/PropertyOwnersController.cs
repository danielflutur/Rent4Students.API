using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.DTOs.PropertyOwner;
using Rent4Students.Application.Services.Interfaces;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyOwnersController : ControllerBase
    {
        private readonly IPropertyOwnerService _ownerService;

        public PropertyOwnersController(IPropertyOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // POST: api/PropertyOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePropertyOwnerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPropertyOwner(PropertyOwnerDTO ownerDTO)
        {
            return Ok(await _ownerService.Create(ownerDTO));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponsePropertyOwnerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _ownerService.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponsePropertyOwnerDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ownerService.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponsePropertyOwnerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, PropertyOwnerDTO ownerDTO)
        {
            return Ok(await _ownerService.Update(ownerDTO));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(_ownerService.Deleted(id));
        }
    }
}
