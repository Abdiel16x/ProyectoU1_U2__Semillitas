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
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnoService service;
        private readonly NewAlumnoValidator validator;

        public AlumnosController(AlumnoService service, NewAlumnoValidator validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpPost]
        public IActionResult Post(CreateAlumnoDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors);

            return Ok(service.Create(dto));
        }

    }
}
