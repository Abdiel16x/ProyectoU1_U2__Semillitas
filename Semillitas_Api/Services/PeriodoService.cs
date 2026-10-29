using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class PeriodoService
    {
        private readonly Repository<Periodos> repository;

        public PeriodoService(Repository<Periodos> repository)
        {
            this.repository = repository;
        }
        public List<PeriodosDTO> GetAll()
        {
            var periodos = repository.GetAll()
                .OrderByDescending(x => x.FechaInicio)
                .Select(x => x.ToDTO())
                .ToList();
            return periodos;
        }

        public PeriodosDTO? GetById(int id)
        {
            var periodo = repository.GetById(id);

            if (periodo == null) return null;

            return periodo.ToDTO();
        }

        public PeriodosDTO? Create(PeriodosDTO dto)
        {
            var data = repository.Add(dto.ToEntity());
            return data.ToDTO();
        }
    }
}