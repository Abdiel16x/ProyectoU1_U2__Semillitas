using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semillitas_Api.Services;
using Semillitas_Api.Validators;
using Semillitas_Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Semillitas_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodosController : ControllerBase
    {
        private readonly PeriodoService service;
        private readonly NewPeriodoValidator validator;

        public PeriodosController(PeriodoService service, NewPeriodoValidator validator)
        {
            this.service = service;
            this.validator = validator;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        

        [HttpPost]
        public IActionResult Post(PeriodosDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors);

            return Ok(service.Create(dto));
        }
    }
}
