using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;
using Semillitas_Core.Validators;

namespace Semillitas_Api.Validators
{
    public class NewPeriodoValidator : PeriodoCreateValidator
    {
        private readonly Repository<Periodos> repository;

        public NewPeriodoValidator(Repository<Periodos> repository)
        {
            this.repository = repository;
        }

        public override ValidationResult IsValid(PeriodosDTO dto)
        {
            var validation = base.IsValid(dto);

            if (repository.GetAll().Any(x => x.Nombre.ToLower() == dto.Nombre.ToLower()))
            {
                validation.Errors.Add("Ya existe un período con ese nombre.");
            }

            return validation;
        }
    }
}
