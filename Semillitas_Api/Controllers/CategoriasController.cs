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
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService service;
        private readonly NewCategoriaValidator validator;

        public CategoriasController(CategoriaService service, NewCategoriaValidator validator)
        {
            this.service = service;
            this.validator = validator;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categorias = service.GetAll();
            return Ok(categorias);
        }

        

        [HttpPost]
        public IActionResult Post(CategoriaDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors);

            var creada = service.Create(dto);
            return Ok(creada);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoriaDTO dto)
        {
            var validation = validator.IsValid(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors);

            var actualizada = service.Update(id, dto);
            if (actualizada == null) return NotFound("Categoría no encontrada");

            return Ok(actualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = service.Delete(id);
            if (!eliminado) return NotFound("Categoría no encontrada");

            return NoContent();
        }
    }
}
