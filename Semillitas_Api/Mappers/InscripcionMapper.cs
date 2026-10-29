using Microsoft.EntityFrameworkCore.ValueGeneration;
using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class InscripcionMapper
    {
        public static InscripcionesDTO ToDTO(this Inscripciones entity)
        {
            var dto = new InscripcionesDTO
            {
                Id = entity.Id,
                Alumno = entity.IdCuentaNavigation.IdAlumnoNavigation.Nombre,
                Taller = entity.IdTallerNavigation.Nombre,
                Periodo = entity.IdCuentaNavigation.IdPeriodoNavigation.Nombre
            };
            return dto;
        }
    }
}
