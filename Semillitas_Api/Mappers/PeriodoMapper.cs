using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class PeriodoMapper
    {
        public static PeriodosDTO ToDTO(this Periodos entity)
        {
            var dto = new PeriodosDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                FechaInicio = entity.FechaInicio,
                FechaFin = entity.FechaFin,
                FechaVencimiento = entity.FechaVencimiento
            };
            return dto;
        }

        public static Periodos ToEntity(this PeriodosDTO dto)
        {
            var entity = new Periodos
            {
                Nombre = dto.Nombre,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                FechaVencimiento = dto.FechaVencimiento
            };
            return entity;
        }
    }
}