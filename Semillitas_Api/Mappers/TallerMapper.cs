using Semillitas_Api.Models.Entities;
using Semillitas_Core.Common;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class TallerMapper
    {
        public static TallerDTO ToDTO(this Talleres entity)
        {
            TallerDTO dto = new TallerDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Categoria = entity.IdCategoriaNavigation.Nombre,
                Instructor = entity.IdInstructorNavigation.Nombre,
                CupoMaximo = entity.CupoMaximo,
                CostoMensual = entity.CostoMensual,
                Horarios = entity.HorariosTaller.Select(x => new HorarioDTO
                {
                    Id = x.Id,
                    DiaSemana = ((DiaSemana)x.DiaSemana).ToString(),
                    HoraInicio = x.HoraInicio,
                    HoraFin = x.HoraFin
                }).ToList()
            };
            return dto;
        }

        public static Talleres ToEntity(this CreateTallerDTO dTO)
        {
            Talleres entity = new Talleres()
            {
                Nombre = dTO.Nombre,
                IdInstructor = dTO.IdInstructor,
                IdCategoria = dTO.IdCategoria,
                CupoMaximo = dTO.CupoMaximo,
                CostoMensual = dTO.CostoMensual
            };

            return entity;
        }
    }
}
