using Semillitas_Core.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class CategoriaCreateValidator
    {
        public virtual ValidationResult IsValid(CategoriaDTO dto)
        {
            var result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(dto.Nombre))
            {
                result.Errors.Add("El nombre de la categoría está vacío.");
            }
            return result;
        }
    }
}
