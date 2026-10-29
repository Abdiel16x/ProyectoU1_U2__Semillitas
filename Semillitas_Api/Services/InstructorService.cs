using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class InstructorService
    {
        private readonly Repository<Instructores> repository;

        public InstructorService(Repository<Instructores> repository)
        {
            this.repository = repository;
        }

        public List<InstructorDTO> GetAll()
        {
            var instructores = repository.GetAll()
                .OrderBy(x => x.Nombre)
                .Select(x => x.ToDTO())
                .ToList();
            return instructores;
        }

        public InstructorDTO? Create(InstructorDTO dto)
        {
            var data = repository.Add(dto.ToEntity());
            return data.ToDTO();
        }
    }
}
