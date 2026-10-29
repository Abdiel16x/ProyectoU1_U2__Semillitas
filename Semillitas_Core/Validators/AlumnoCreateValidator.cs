using Semillitas_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class AlumnoCreateValidator
    {
        public virtual ValidationResult IsValid(CreateAlumnoDTO dto)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(dto.NombreAlumno))
            {
                result.Errors.Add("El nombre del alumno está vacío.");
            }

            if (dto.FechaNacimiento >= DateOnly.FromDateTime(DateTime.Now))
            {
                result.Errors.Add("La fecha de nacimiento debe ser en el pasado.");
            }

            return result;
        }
    }
}
