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
    public class TalleresController : ControllerBase
    {
        private readonly TallerService service;
        private readonly NewTallerValidator validator;

        public TalleresController(TallerService service, NewTallerValidator validator)
        {
            this.service = service;
            this.validator = validator;
        }
        [HttpGet]
        public ActionResult<List<TallerDTO>> Get()
        {
            var talleres = service.GetAll();
            return Ok(talleres);
        }

        [HttpGet("{id}")]
        public ActionResult<TallerDTO> GetById(int id)
        {
            var taller = service.GetById(id);

            if (taller == null)
                return NotFound("Taller no encontrado");

            return Ok(taller);
        }

        [HttpPost]
        public ActionResult<TallerDTO> Post([FromBody] CreateTallerDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            return Ok(service.Create(dto));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CreateTallerDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors);

            var actualizado = service.Update(id, dto);
            if (actualizado == null) return NotFound("Taller no encontrado");

            return Ok(actualizado);
        }
    }
}