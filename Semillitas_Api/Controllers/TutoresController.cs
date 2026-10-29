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
    public class TutoresController : ControllerBase
    {
        private readonly TutorService service;
        private readonly NewTutorValidator validator;

        public TutoresController(TutorService service, NewTutorValidator validator)
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
        public IActionResult Post(TutorDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors);

            return Ok(service.Create(dto));
        }
    }
}
