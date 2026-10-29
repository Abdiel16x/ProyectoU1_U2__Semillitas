using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semillitas_Api.Services;

namespace Semillitas_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly CuentaService service;

        public CuentasController(CuentaService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        [HttpPatch("{id}/pagar")]
        public IActionResult Pagar(int id, [FromQuery] bool pagado)
        {
            var cuenta = service.MarcarPagada(id, pagado);

            if (cuenta == null)
                return NotFound("Cuenta no encontrada");

            return Ok(cuenta);
        }
    }
}
