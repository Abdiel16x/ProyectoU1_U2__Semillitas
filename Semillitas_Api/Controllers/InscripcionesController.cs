using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semillitas_Api.Services;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly InscripcionService service;

        public InscripcionesController(InscripcionService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post(CreateInscripcionDTO dto)
        {
            
            var inscripcion = service.Create(dto);

            if (inscripcion == null)
            {
                return BadRequest("No se pudo completar la inscripción. Verifique el cupo, el período o los choques de horario.");
            }

            return Ok(inscripcion);
        }
    }
}
