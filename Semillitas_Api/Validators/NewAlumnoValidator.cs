using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;
using Semillitas_Core.Validators;

namespace Semillitas_Api.Validators
{
    public class NewAlumnoValidator : AlumnoCreateValidator
    {
        private readonly Repository<Tutores> repository;
        private readonly Repository<Alumnos> repositoryAlumnos;

        public NewAlumnoValidator(Repository<Tutores> repository, Repository<Alumnos> repositoryAlumnos)
        {
            this.repository = repository;
            this.repositoryAlumnos = repositoryAlumnos;
        }

        public override ValidationResult IsValid(CreateAlumnoDTO dto)
        {
            var validation = base.IsValid(dto);

            var tutor = repository.GetById(dto.IdTutor);
            if (tutor == null)
                validation.Errors.Add("El tutor especificado no existe.");

            var alumnoExistente = repositoryAlumnos.Query()
                .Any(x => x.Nombre.ToLower() == dto.NombreAlumno.ToLower()
                       && x.IdTutor == dto.IdTutor);

            if (alumnoExistente)
                validation.Errors.Add("Este tutor ya tiene registrado un alumno con ese mismo nombre.");

            return validation;
        }
    }
}
