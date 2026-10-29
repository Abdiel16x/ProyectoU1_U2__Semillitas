using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class TallerService
    {
        private readonly Repository<Talleres> repository;

        public TallerService(Repository<Talleres> repository)
        {
            this.repository = repository;
        }

        public List<TallerDTO> GetAll()
        {
            var talleres = repository.Query()
                .Include(x => x.IdCategoriaNavigation)
                .Include(x => x.IdInstructorNavigation)
                .Include(x => x.HorariosTaller)
                .OrderBy(x => x.Nombre).Select(x => x.ToDTO())
                .ToList();

            return talleres;
        }

        public TallerDTO? GetById(int id)
        {
            var taller = repository.Query()
                .Include(x => x.IdCategoriaNavigation)
                .Include(x => x.IdInstructorNavigation)
                .Include(x => x.HorariosTaller)
                .Where(x => x.Id == id)
                .Select(x => x.ToDTO())
                .FirstOrDefault();

            return taller;
        }

        public TallerDTO Create(CreateTallerDTO dto)
        {
            var nuevoTaller = dto.ToEntity();

            foreach (var horarioDto in dto.Horarios)
            {
                nuevoTaller.HorariosTaller.Add(new HorariosTaller
                {
                    DiaSemana = horarioDto.DiaSemana,
                    HoraInicio = horarioDto.HoraInicio,
                    HoraFin = horarioDto.HoraFin
                });
            }

            var data = repository.Add(nuevoTaller);

            return GetById(data.Id);
        }
    }

}
