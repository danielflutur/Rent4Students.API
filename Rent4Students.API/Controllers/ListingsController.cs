using Microsoft.AspNetCore.Mvc;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.RentHistory;
using Rent4Students.Application.Services.Interfaces;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingsController(IListingService listingService)
        {
            _listingService = listingService;
        }

        // POST: api/Listings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ResponseListingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateListing(ListingDTO listingDTO)
        {
            return Ok(await _listingService.Create(listingDTO));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseListingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _listingService.GetById(id));
        }

        [HttpGet]
        [Route("ownedBy/{id}")]
        [ProducesResponseType(typeof(List<ResponseOwnerListingsDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOwnedBy(Guid id)
        {
            return Ok(await _listingService.GetAllOwnedBy(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseListingDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _listingService.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseListingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, ListingDTO listingDTO)
        {
            return Ok(await _listingService.Update(listingDTO));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _listingService.Delete(id);

            return Ok(id);
        }

        [HttpPost]
        [Route("rent-contract")]
        [ProducesResponseType(typeof(ResponseListingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRentRequest(ListingRentRequestDTO rentRequestDTO)
        {
            return Ok(await _listingService.CreateRentRequest(rentRequestDTO));
        }

        [HttpPost]
        [Route("accept-rent")]
        [ProducesResponseType(typeof(ResponseOwnerListingsDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AcceptRentRequest(AcceptRentHistoryDTO rentRequestDTO)
        {
            await _listingService.AcceptRentRequest(rentRequestDTO);
            return Ok();
        }

        [HttpPost]
        [Route("reject-rent")]
        [ProducesResponseType(typeof(ResponseOwnerListingsDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RejectRentRequest(Guid id)
        {
            await _listingService.RejectRentRequest(id);
            return Ok();
        }
    }
}
