using Semillitas_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class PeriodoCreateValidator
    {
        public virtual ValidationResult IsValid(PeriodosDTO dto)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                result.Errors.Add("El nombre del período está vacío.");

            if (dto.FechaInicio > dto.FechaFin)
                result.Errors.Add("La fecha de inicio no puede ser mayor a la fecha de fin.");

            return result;
        }
    }
}
