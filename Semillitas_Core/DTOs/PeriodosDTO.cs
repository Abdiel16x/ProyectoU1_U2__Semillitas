using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class CreatePeriodoDTO
    {
        [Required(ErrorMessage = "Se debe escribir el nombre del período")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Se debe escribir la fecha de inicio")]
        public DateOnly FechaInicio { get; set; }

        [Required(ErrorMessage = "Se debe escribir la fecha de fin")]
        public DateOnly FechaFin { get; set; }

        [Required(ErrorMessage = "Se debe escribir la fecha de vencimiento")]
        public DateOnly FechaVencimiento { get; set; }
    }
    public class PeriodosDTO:CreatePeriodoDTO
    {
        public int Id { get; set; }
    }
}
