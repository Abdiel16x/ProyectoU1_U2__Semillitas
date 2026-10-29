using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;
using Semillitas_Core.Validators;

namespace Semillitas_Api.Validators
{
    public class NewTutorValidator : TutorCreateValidator
    {
        private readonly Repository<Tutores> repository;

        public NewTutorValidator(Repository<Tutores> repository)
        {
            this.repository = repository;
        }

        public override ValidationResult IsValid(TutorDTO dto)
        {
            var validation = base.IsValid(dto);

            if (repository.GetAll().Any(x => x.Telefono == dto.Telefono))
                validation.Errors.Add("Ya existe un tutor registrado con ese número de teléfono.");

            return validation;
        }
    }
}
