

using System.ComponentModel.DataAnnotations;

namespace Semillitas_Core.DTOs
{
    public class HorarioDTO
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; } = null!;
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }

    }

    public class CreateHorarioDTO
    {
        [Required(ErrorMessage = "Debe indicar el día de la semana")]
        [Range(1, 7, ErrorMessage = "El día debe ser entre 1 (Lunes) y 6 (Sábado)")]
        public int DiaSemana { get; set; }
        [Required(ErrorMessage = "Debe indicar la hora de inicio")]
        public TimeOnly HoraInicio { get; set; }
        [Required(ErrorMessage = "Debe indicar la hora de fin")]
        public TimeOnly HoraFin { get; set; }
    }
}