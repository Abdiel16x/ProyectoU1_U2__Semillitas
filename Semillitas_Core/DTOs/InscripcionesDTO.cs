using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class InscripcionesDTO
    {
        public int Id { get; set; }
        public string Alumno { get; set; } = null!;
        public string Taller { get; set; } = null!;
        public string Periodo { get; set; } = null!;
    }

    public class CreateInscripcionDTO
    {
        [Required(ErrorMessage ="el Id del alumno es obligatorio")]
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "el Id del taller es obligatorio")]
        public int IdTaller { get; set; }
        [Required(ErrorMessage = "el Id del periodo es obligatorio")]
        public int IdPeriodo { get; set; }
    }
}
