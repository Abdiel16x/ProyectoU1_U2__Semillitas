using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;
using Semillitas_Core.Validators;
namespace Semillitas_Api.Validators
{
    public class NewCategoriaValidator : CategoriaCreateValidator
    {
        private readonly Repository<Categorias> repository;

        public NewCategoriaValidator(Repository<Categorias> repository)
        {
            this.repository = repository;
        }

        public override ValidationResult IsValid(CategoriaDTO dTO)
        {
            var validation = base.IsValid(dTO);

            if (repository.GetAll().Any(x => x.Nombre.ToLower() == dTO.Nombre.ToLower()))
            {
                validation.Errors.Add("Ya existe una categoría con ese nombre.");
            }

            return validation;
        }
    }
}
