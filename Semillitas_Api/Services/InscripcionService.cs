using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class InscripcionService
    {
        private readonly Repository<Inscripciones> inscripcionRepo;
        private readonly Repository<Talleres> tallerRepo;
        private readonly Repository<Cuentas> cuentaRepo;
        private readonly Repository<Periodos> periodoRepo;
        private readonly Repository<Alumnos> alumnoRepo;

        public InscripcionService(Repository<Inscripciones> inscripcionRepo, Repository<Talleres> tallerRepo, Repository<Cuentas> cuentaRepo, Repository<Periodos> periodoRepo, Repository<Alumnos> alumnoRepo)
        {
            this.inscripcionRepo = inscripcionRepo;
            this.tallerRepo = tallerRepo;
            this.cuentaRepo = cuentaRepo;
            this.periodoRepo = periodoRepo;
            this.alumnoRepo = alumnoRepo;
        }

        public InscripcionesDTO? Create(CreateInscripcionDTO dTO)
        {
            var periodo = periodoRepo.GetById(dTO.IdPeriodo);
            if (periodo == null || periodo.FechaInicio <= DateOnly.FromDateTime(DateTime.Now))
                return null;

            var taller = tallerRepo.GetById(dTO.IdTaller);
            if (taller == null) return null;

            var inscritos = inscripcionRepo.Query().Count(i => i.IdTaller == dTO.IdTaller);
            if (inscritos >= taller.CupoMaximo) return null;

            var cuenta = cuentaRepo.Query().FirstOrDefault(c => c.IdAlumno == dTO.IdAlumno && c.IdPeriodo == dTO.IdPeriodo);
            if (cuenta == null)
            {
                cuenta = new Cuentas 
                { 
                    IdAlumno = dTO.IdAlumno, 
                    IdPeriodo = dTO.IdPeriodo,
                    Pagado = false 
                };

                cuentaRepo.Add(cuenta);
            }

            var horariosDelAlumno = inscripcionRepo.Query()
               .Where(i => i.IdCuenta == cuenta.Id)
               .Include(i => i.IdTallerNavigation.HorariosTaller)
               .SelectMany(i => i.IdTallerNavigation.HorariosTaller
               .ToList());

            var horariosNuevos = tallerRepo.Query()
                .Include(t => t.HorariosTaller)
                .Where(t => t.Id == dTO.IdTaller)
                .SelectMany(t => t.HorariosTaller)
                .ToList();

            var hayChoque = horariosNuevos.Any(nuevo =>
                horariosDelAlumno.Any(existente =>
                    nuevo.DiaSemana == existente.DiaSemana &&
                    nuevo.HoraInicio < existente.HoraFin &&
                    nuevo.HoraFin > existente.HoraInicio
                )
            );
  

            if (hayChoque) return null;

            var inscripcionNueva = new Inscripciones
            {
                IdCuenta = cuenta.Id,
                IdTaller = dTO.IdTaller
            };
            inscripcionRepo.Add(inscripcionNueva);

            var entity = inscripcionRepo.Query()
                .Include(x => x.IdCuentaNavigation).ThenInclude(x => x.IdAlumnoNavigation)
                .Include(x => x.IdCuentaNavigation).ThenInclude(x => x.IdPeriodoNavigation)
                .Include(x => x.IdTallerNavigation)
                .Where(x => x.Id == inscripcionNueva.Id)
                .First();

            return entity.ToDTO();
        }
    }
}
