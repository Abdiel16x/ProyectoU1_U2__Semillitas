using System;
using System.Collections.Generic;
using System.Text;

namespace Semillitas_Core.DTOs
{
    public class InscritosPorTallerDTO
    {
        public string NombreTaller { get; set; } = null!;
        public int CupoMaximo { get; set; }
        public int InscritosActuales { get; set; }
        public int Disponibles { get; set; }
    }
    public class ResumenIngresosDTO
    {
        public string NombrePeriodo { get; set; } = null!;
        public decimal IngresosCobrados { get; set; }
        public decimal PorCobrar { get; set; }
    }

    public class RankingTallerDTO
    {
        public string NombreTaller { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public int TotalInscripciones { get; set; }
    }
}
