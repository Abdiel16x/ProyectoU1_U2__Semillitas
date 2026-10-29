using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semillitas_Api.Services;

namespace Semillitas_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly ReporteService service;

        public ReportesController(ReporteService service)
        {
            this.service = service;
        }
        [HttpGet("inscritos-por-taller/{idPeriodo}")]
        public IActionResult GetInscritos(int idPeriodo)
        {
            return Ok(service.GetInscritosPorTaller(idPeriodo));
        }

        [HttpGet("resumen-ingresos/{idPeriodo}")]
        public IActionResult GetIngresos(int idPeriodo)
        {
            return Ok(service.GetResumenIngresos(idPeriodo));
        }

        [HttpGet("ranking-talleres/{idPeriodo}")]
        public IActionResult GetRanking(int idPeriodo)
        {
            return Ok(service.GetRankingTalleres(idPeriodo));
        }
    }
}