using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class AlumnoMapper
    {
        public static AlumnosDTO ToDTO(this Alumnos entity)
        {
            var dto = new AlumnosDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                NombreTutor = entity.IdTutorNavigation.Nombre,
                FechaNacimiento = entity.FechaNacimiento

            };
            return dto;
        }

        public static Alumnos ToEntity(this CreateAlumnoDTO dTO)
        {
            var entity = new Alumnos
            {
                Nombre = dTO.NombreAlumno,
                FechaNacimiento = dTO.FechaNacimiento,
                IdTutor = dTO.IdTutor
            };
            return entity;
        }
    }
}
