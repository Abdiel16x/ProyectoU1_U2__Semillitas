using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class CuentaService
    {
        private readonly Repository<Cuentas> repository;

        public CuentaService(Repository<Cuentas> repository)
        {
            this.repository = repository;
        }

        public List<CuentaDTO> GetAll()
        {
            var cuentas = repository.Query()
                .Include(x => x.IdAlumnoNavigation)
                .Include(x => x.IdPeriodoNavigation)
                .Include(x => x.Inscripciones)
                    .ThenInclude(i => i.IdTallerNavigation)
                .OrderBy(x => x.IdAlumnoNavigation.Nombre)
                .Select(x => x.ToDTO())
                .ToList();

            return cuentas;
        }

        public CuentaDTO? MarcarPagada(int idCuenta, bool pagado)
        {
            var cuenta = repository.Query()
                .Include(x => x.IdAlumnoNavigation)
                .Include(x => x.IdPeriodoNavigation)
                .Include(x => x.Inscripciones)
                    .ThenInclude(x => x.IdTallerNavigation)
                .FirstOrDefault(x => x.Id == idCuenta);

            if (cuenta == null) return null;

            cuenta.Pagado = pagado;
            cuenta.FechaPago = pagado ? DateOnly.FromDateTime(DateTime.Now) : null;

            repository.Update(cuenta);

            return cuenta.ToDTO();
        }
    }
}
