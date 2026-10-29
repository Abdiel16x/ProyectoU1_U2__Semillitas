using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class CreateTutorDTO
    {
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
    public class TutorDTO : CreateTutorDTO
    {
        public int Id { get; set; }
    }
}
