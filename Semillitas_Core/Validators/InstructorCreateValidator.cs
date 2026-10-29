using Semillitas_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class InstructorCreateValidator
    {
        public virtual ValidationResult IsValid(InstructorDTO dto)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(dto.Nombre))
            {
                result.Errors.Add("El nombre del instructor está vacío.");
            }

            return result;
        }
    }
}
