using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPersonas.Application.DTOs;
using ProjectPersonas.Application.Services;

namespace ProjectPersonas.WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EspecialidadesController : Controller
    {
        private readonly EspecialidadService _especialidadService;
        public EspecialidadesController(EspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadDto>>> GetAll()
        {
            try
            {
                var especialidades = await _especialidadService.GetAllEspecialidadAsync();
                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EspecialidadDto>> GetById(int id)
        {
            try
            {
                var especialidad = await _especialidadService.GetEspecialidadByIdAsync(id);
                if (especialidad == null)
                {
                    return NotFound($"Especialidad with ID {id} not found.");
                }
                return Ok(especialidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<EspecialidadDto>> Create([FromBody] CreateEspecialidadDto especialidadDto)
        {
            if (especialidadDto == null)
            {
                return BadRequest("Invalid especialidad data.");
            }
            try
            {
                var createdEspecialidad = await _especialidadService.AddEspecialidadAsync(especialidadDto);
                return CreatedAtAction(nameof(GetById), new { id = createdEspecialidad.Id }, createdEspecialidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEspecialidadDto especialidadDto)
        {
            if (especialidadDto == null)
            {
                return BadRequest("Invalid especialidad data.");
            }
            try
            {
                await _especialidadService.UpdateEspecialidadAsync(id, especialidadDto);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _especialidadService.DeleteEspecialidadAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
