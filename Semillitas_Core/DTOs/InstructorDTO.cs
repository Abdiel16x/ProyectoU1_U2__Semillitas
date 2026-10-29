using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class InstructorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del instructor es obligatorio")]
        public string Nombre { get; set; } = null!;
    }
}
