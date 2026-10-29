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
    public class InstructoresController : ControllerBase
    {
        private readonly InstructorService service;
        private readonly NewInstructorValidator validator;

        public InstructoresController(InstructorService service, NewInstructorValidator validator)
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
        public IActionResult Post(InstructorDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            return Ok(service.Create(dto));
        }
    }
}
