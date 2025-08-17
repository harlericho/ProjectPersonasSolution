using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPersonas.Application.DTOs;
using ProjectPersonas.Application.Services;

namespace ProjectPersonas.WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonasController : Controller
    {
        private readonly PersonaService _personaService;
        public PersonasController(PersonaService personaService)
        {
            _personaService = personaService;
        }
        [HttpGet]
        //public async Task<IActionResult> GetAllPersonas()
        //{
        //    var personas = await _personaService.GetAllPersonasAsync();
        //    return Ok(personas);
        //}
        public async Task<IActionResult> GetAllPersonasEspecialidad()
        {
            var personas = await _personaService.GetAllPersonasEspecialidadAsync();
            return Ok(personas);
        }
        [HttpGet("{id:int}")]
        //public async Task<IActionResult> GetPersonaById(int id)
        //{
        //    var persona = await _personaService.GetPersonaByIdAsync(id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(persona);
        //}
        public async Task<IActionResult> GetPersonaById(int id)
        {
            try
            {
                var persona = await _personaService.GetPersonaByIdWithEspecialidadAsync(id);
                return Ok(persona);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Persona with ID {id} not found.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<PersonaDto>> CreatePersona([FromBody] CreatePersonaDto personaDto)
        {
            if (personaDto == null)
            {
                return BadRequest("Persona data is required.");
            }
            await _personaService.AddPersonaAsync(personaDto);
            return CreatedAtAction(nameof(GetPersonaById), new { id = personaDto.Cedula }, personaDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePersona(int id, [FromBody] UpdatePersonaDto personaDto)
        {
            if (personaDto == null)
            {
                return BadRequest("Persona data is required.");
            }
            try
            {
                await _personaService.UpdatePersonaAsync(id, personaDto);
                return Ok(new { message = $"Persona with ID {id} updated successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Persona with ID {id} not found.");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            try
            {
                await _personaService.DeletePersonaAsync(id);
                return Ok(new { message = $"Persona with ID {id} deleted successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Persona with ID {id} not found.");
            }
        }
    }
}
