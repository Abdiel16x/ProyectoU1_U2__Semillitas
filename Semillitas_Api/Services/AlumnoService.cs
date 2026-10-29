using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class AlumnoService
    {
        private readonly Repository<Alumnos> repository;

        public AlumnoService(Repository<Alumnos> repository)
        {
            this.repository = repository;
        }

        public List<AlumnosDTO> GetAll()
        {
            var alumnos = repository.Query()
                .Include(x => x.IdTutorNavigation)
                .OrderBy(x => x.Nombre)
                .Select(x => x.ToDTO()).ToList();
            return alumnos;
        }

        public AlumnosDTO? Create(CreateAlumnoDTO dto)
        {
            var data = repository.Add(dto.ToEntity());

            var alumno = repository.Query()
                .Include(x => x.IdTutorNavigation)
                .Where(x => x.Id == data.Id)
                .Select(x => x.ToDTO())
                .FirstOrDefault();

            return alumno;
        }
    }
}
