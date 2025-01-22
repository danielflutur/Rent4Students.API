using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent4Students.Application.DTOs.Listing;
using Rent4Students.Application.DTOs.University;
using Rent4Students.Application.Services;
using Rent4Students.Application.Services.Interfaces;
using Rent4Students.Domain.Entities;
using Rent4Students.Infrastructure.Data;

namespace Rent4Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        // POST: api/Universities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUniversityDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUniversity(UniversityDTO universityDTO)
        {
            return Ok(await _universityService.Create(universityDTO));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseUniversityDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _universityService.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseUniversityDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _universityService.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseUniversityDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, UniversityDTO universityDTO)
        {
            return Ok(await _universityService.Update(universityDTO));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _universityService.Delete(id);

            return Ok(id);
        }
    }
}
