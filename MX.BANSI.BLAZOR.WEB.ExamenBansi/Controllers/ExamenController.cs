namespace MX.BANSI.BLAZOR.WEB.ExamenBansi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MX.BANSI.BLAZOR.WEB.ExamenBansi.Services;
    using MX.BANSI.CORE.DLL.DOMAIN.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class ExamenController : ControllerBase     
    {
        private readonly ExamenApiService _examenApiService;

        public ExamenController(ExamenApiService examenApiService)
        {
            _examenApiService = examenApiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Examen>>> GetAllExamenes()
        {
            var examenes = await _examenApiService.GetAllExamenesAsync();
            return Ok(examenes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Examen>> GetExamenById(int id)
        {
            var examen = await _examenApiService.GetExamenByIdAsync(id);
            if (examen == null)
            {
                return NotFound();
            }
            return Ok(examen);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExamen(Examen examen)
        {
            await _examenApiService.CreateExamenAsync(examen);
            return CreatedAtAction(nameof(GetExamenById), new { id = examen.Id }, examen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamen(int id, Examen examen)
        {
            if (id != examen.Id)
            {
                return BadRequest();
            }

            await _examenApiService.UpdateExamenAsync(examen);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamen(int id)
        {
            var examen = await _examenApiService.GetExamenByIdAsync(id);
            if (examen == null)
            {
                return NotFound();
            }

            await _examenApiService.DeleteExamenAsync(id);
            return NoContent();
        }
    }

}
