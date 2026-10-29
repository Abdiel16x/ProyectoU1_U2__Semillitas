using Semillitas_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class TutorCreateValidator
    {
        public virtual ValidationResult IsValid(TutorDTO dto)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                result.Errors.Add("El nombre del tutor está vacío.");

            if (string.IsNullOrWhiteSpace(dto.Telefono))
                result.Errors.Add("El teléfono es obligatorio.");

            return result;
        }
    }
}
