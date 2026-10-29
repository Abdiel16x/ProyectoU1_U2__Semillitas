using Semillitas_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;
using Semillitas_Core.Validators;
namespace Semillitas_Api.Validators
{
    public class NewTallerValidator : TallerCreateValidator
    {
        private readonly Repository<Talleres> repositoryTalleres;
        private readonly Repository<Categorias> repositoryCategorias;
        private readonly Repository<Instructores> repositoryInstructores;

        public NewTallerValidator(Repository<Talleres> repositoryTalleres, Repository<Categorias> repositoryCategorias, Repository<Instructores> repositoryInstructores)
        {
            this.repositoryTalleres = repositoryTalleres;
            this.repositoryCategorias = repositoryCategorias;
            this.repositoryInstructores = repositoryInstructores;
        }

        public override ValidationResult IsValid(CreateTallerDTO dto)
        {
            var validation = base.IsValid(dto);

            if (repositoryCategorias.GetById(dto.IdCategoria) == null)
                validation.Errors.Add("La categoría especificada no existe.");

            if (repositoryInstructores.GetById(dto.IdInstructor) == null)
                validation.Errors.Add("El instructor especificado no existe.");

            var tallerDuplicado = repositoryTalleres.Query()
                .Any(x => x.Nombre.ToLower() == dto.Nombre.ToLower()
                       && x.IdCategoria == dto.IdCategoria);

            if (tallerDuplicado)
                validation.Errors.Add("Ya existe un taller con ese nombre en esta categoría.");

            var talleresDelInstructor = repositoryTalleres.Query()
                .Include(t => t.HorariosTaller)
                .Where(t => t.IdInstructor == dto.IdInstructor)
                .ToList();

            foreach (var nuevoHorario in dto.Horarios)
            {
                foreach (var tallerExistente in talleresDelInstructor)
                {
                    foreach (var horarioExistente in tallerExistente.HorariosTaller)
                    {
                        if (nuevoHorario.DiaSemana == horarioExistente.DiaSemana &&
                            nuevoHorario.HoraInicio < horarioExistente.HoraFin &&
                            nuevoHorario.HoraFin > horarioExistente.HoraInicio)
                        {
                            validation.Errors.Add($"El instructor ya tiene otro taller el día {nuevoHorario.DiaSemana} en ese horario.");
                            return validation; 
                        }
                    }
                }
            }

            return validation;
        }
    }
}
