using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class AlumnosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string NombreTutor { get; set; } = null!;
    }

    public class CreateAlumnoDTO
    {
        [Required(ErrorMessage ="se debe inicar el id del tutor")]
        public int IdTutor { get; set; }
        [Required(ErrorMessage = "Debes escribir el nombre del alumno")]
        public string NombreAlumno { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
    }
}
