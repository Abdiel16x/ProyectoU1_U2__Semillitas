using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class TutorService
    {
        private readonly Repository<Tutores> repository;

        public TutorService(Repository<Tutores> repository)
        {
            this.repository = repository;
        }

        public List<TutorDTO> GetAll()
        {
            var instructores = repository.GetAll()
                .OrderBy(x => x.Nombre)
                .Select(x => x.ToDTO())
                .ToList();
            return instructores;
        }

        public TutorDTO? Create(TutorDTO dto)
        {
            var data = repository.Add(dto.ToEntity());
            return data.ToDTO();
        }
    }
}
