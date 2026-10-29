using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Semillitas_Api.Mappers
{
    public static class TutorMapper
    {
        public static TutorDTO ToDTO(this Tutores entity)
        {
            var dto = new TutorDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Telefono = entity.Telefono
            };
            return dto;
        }

        public static Tutores ToEntity (this CreateTutorDTO dTO)
        {
            var entity = new Tutores
            {
                Nombre = dTO.Nombre,
                Telefono = dTO.Telefono
            };
            return entity;
        }
    }
}
