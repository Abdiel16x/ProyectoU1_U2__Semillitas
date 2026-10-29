using Semillitas_Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class TallerDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Instructor { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public int CupoMaximo { get; set; }
        public decimal CostoMensual { get; set; }
        public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
    }
    public class CreateTallerDTO
    {
        [Required(ErrorMessage = "El nombre del taller es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Debe indicar el instructor")]
        public int IdInstructor { get; set; }
        [Required(ErrorMessage = "Debe indicar la categoría")]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Debe indicar el cupo máximo")]
        public int CupoMaximo { get; set; }
        [Required(ErrorMessage = "Debe indicar el costo mensual")]
        public decimal CostoMensual { get; set; }
        [Required(ErrorMessage = "Debe agregar al menos un horario")]
        [MinLength(1, ErrorMessage = "Debe agregar al menos un horario")]
        public List<CreateHorarioDTO> Horarios { get; set; } = new List<CreateHorarioDTO>();
    }
}
