using Semillitas_Api.Models.Entities;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Mappers
{
    public static class CuentaMapper
    {
        public static CuentaDTO ToDTO(this Cuentas entity)
        {
            var dto = new CuentaDTO
            {
                Id = entity.Id,
                IdAlumno = entity.IdAlumno,
                Alumno = entity.IdAlumnoNavigation.Nombre,
                Periodo = entity.IdPeriodoNavigation.Nombre,
                Pagado = entity.Pagado,
                FechaPago = entity.FechaPago,
                TotalCalculado = entity.Inscripciones.Sum(x => x.IdTallerNavigation.CostoMensual)
            };
            return dto;
        }
    }
}
