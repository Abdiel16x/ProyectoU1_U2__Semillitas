using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class CuentaDTO
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; } 
        public string Alumno { get; set; } = null!;
        public string Periodo { get; set; } = null!;
        public DateOnly? FechaPago { get; set; }
        public bool Pagado { get; set; }
        public decimal TotalCalculado { get; set; }

    }

    public class UpdateCuentaDTO
    {
        [Required(ErrorMessage ="Se debe indicar si esta pagado o no")]
        public bool Pagado { get; set; }
        public DateOnly? FechaPago { get; set; }
    }
}
