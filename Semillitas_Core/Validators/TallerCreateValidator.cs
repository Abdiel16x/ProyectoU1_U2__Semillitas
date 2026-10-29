using Semillitas_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.Validators
{
    public class TallerCreateValidator
    {
        public virtual ValidationResult IsValid(CreateTallerDTO dto)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                result.Errors.Add("El nombre del taller es obligatorio.");

            if (dto.CupoMaximo <= 0)
                result.Errors.Add("El cupo máximo debe ser mayor a 0.");

            if (dto.CostoMensual <= 0)
                result.Errors.Add("El costo mensual debe ser mayor a 0.");

            if (dto.Horarios == null || !dto.Horarios.Any())
            {
                result.Errors.Add("Debe agregar al menos un horario para el taller.");
            }
            else
            {
                foreach (var horario in dto.Horarios)
                {
                    if (horario.DiaSemana < 1 || horario.DiaSemana > 7)
                    {
                        result.Errors.Add("El día de la semana debe estar entre 1 (Lunes) y 6 (Sábado).");
                    }

                    if (horario.HoraFin <= horario.HoraInicio)
                    {
                        result.Errors.Add("La hora de fin debe ser mayor a la hora de inicio.");
                    }
                }
            }

            return result;
        }
    }
}
