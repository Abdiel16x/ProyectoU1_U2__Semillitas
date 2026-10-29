using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class CategoriaMapper
    {
        public static CategoriaDTO ToDTO(this Categorias entity)
        {
            var dto = new CategoriaDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
            return dto;
        }

        public static Categorias ToEntity(this CategoriaDTO dTO)
        {
            var categoria = new Categorias
            {
                Nombre = dTO.Nombre,
            };

            return categoria;
        }
    }
}
