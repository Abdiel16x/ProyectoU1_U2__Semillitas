using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class InstructorMapper
    {
        public static InstructorDTO ToDTO(this Instructores entity)
        {
            var dto = new InstructorDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
            return dto;
        }

        public static Instructores ToEntity(this InstructorDTO dto)
        {
            var entity = new Instructores
            {
                Nombre = dto.Nombre
            };
            return entity;
        }
    }
}
