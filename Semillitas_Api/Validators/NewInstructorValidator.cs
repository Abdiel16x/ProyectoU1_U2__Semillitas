using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;
using Semillitas_Core.Validators;

namespace Semillitas_Api.Validators
{
    public class NewInstructorValidator : InstructorCreateValidator
    {
        private readonly Repository<Instructores> repository;

        public NewInstructorValidator(Repository<Instructores> repository)
        {
            this.repository = repository;
        }

        public override ValidationResult IsValid(InstructorDTO dto)
        {
            var validation = base.IsValid(dto);

            if (repository.GetAll().Any(x => x.Nombre.ToLower() == dto.Nombre.ToLower()))
            {
                validation.Errors.Add("Ya existe un instructor con ese nombre.");
            }

            return validation;
        }
    }
}
