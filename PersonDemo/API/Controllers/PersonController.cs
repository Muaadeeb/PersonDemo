using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelDTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet("getallpersons")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
	            var result = await _personManager.GetAllPersonsAsync();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorDTO()
                {
                    Title = "Book Controller",
                    ErrorMessage = $"GetAllPersons had an error - {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpGet("getpersonbypersonid")]
        public async Task<IActionResult> GetPersonByPersonId(int personId)
        {
            var result = await _personManager.GetPersonAsync(personId);
            return Ok(result);
        }
        
        //[HttpGet("searchvalue")]
        //public async Task<IActionResult> GetBooksBySearchValueAsync(string bookSearchValue)
        //{
        //    var result = await _personManager.GetBooksBySearchValueAsync(bookSearchValue);
        //    return Ok(result);
        //}

        [HttpPost("updateperson")]
        public async Task<IActionResult> UpdatePersonAsync([FromBody] PersonDTO personDto)
        {
            try
            {
	            var result = await _personManager.UpdatePersonAsync(personDto);
                if (result != null)
                {
                    return Ok(StatusCodes.Status200OK);
                }

                return BadRequest(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO()
                {
                    Title = "Person Controller",
                    ErrorMessage = $"Update Person had an error - {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpPut("createperson")]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDTO personDto)
        {
            try
            {
	            var result = await _personManager.CreatePersonAsync(personDto);
                if (result != null)
                {
                    return Ok(StatusCodes.Status201Created);
                }

                return BadRequest(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO()
                {
                    Title = "Person Controller",
                    ErrorMessage = $"Create Person had an error - {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpDelete("deletepersonbypersonid")]
        public async Task<int> DeletePersonByPersonId(int personId)
        {
            return await _personManager.DeletePersonAsync(personId);
        }
    }
}
