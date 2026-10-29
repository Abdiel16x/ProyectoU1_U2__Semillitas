using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class ReporteService
    {
        private readonly Repository<Inscripciones> inscripcionRepo;
        private readonly Repository<Talleres> tallerRepo;
        private readonly Repository<Cuentas> cuentaRepo;

        public ReporteService(Repository<Inscripciones> inscripcionRepo, Repository<Talleres> tallerRepo, Repository<Cuentas> cuentaRepo)
        {
            this.inscripcionRepo = inscripcionRepo;
            this.tallerRepo = tallerRepo;
            this.cuentaRepo = cuentaRepo;
        }
        public List<InscritosPorTallerDTO> GetInscritosPorTaller(int idPeriodo)
        {
            return tallerRepo.Query()
                .Select(t => new InscritosPorTallerDTO
                {
                    NombreTaller = t.Nombre,
                    CupoMaximo = t.CupoMaximo,
                    InscritosActuales = t.Inscripciones.Count(i => i.IdCuentaNavigation.IdPeriodo == idPeriodo),
                    Disponibles = t.CupoMaximo - t.Inscripciones.Count(i => i.IdCuentaNavigation.IdPeriodo == idPeriodo)
                }).ToList();
        }

       
        public ResumenIngresosDTO GetResumenIngresos(int idPeriodo)
        {
            var cuentasDelPeriodo = cuentaRepo.Query()
                .Include(c => c.IdPeriodoNavigation)
                .Include(c => c.Inscripciones).ThenInclude(i => i.IdTallerNavigation)
                .Where(c => c.IdPeriodo == idPeriodo)
                .ToList();

            var periodoNombre = cuentasDelPeriodo.FirstOrDefault()?.IdPeriodoNavigation?.Nombre ?? "Sin período";

            return new ResumenIngresosDTO
            {
                NombrePeriodo = periodoNombre,
                
                IngresosCobrados = cuentasDelPeriodo.Where(c => c.Pagado).SelectMany(c => c.Inscripciones).Sum(i => i.IdTallerNavigation.CostoMensual),
               
                PorCobrar = cuentasDelPeriodo.Where(c => !c.Pagado).SelectMany(c => c.Inscripciones).Sum(i => i.IdTallerNavigation.CostoMensual)
            };
        }

      
        public List<RankingTallerDTO> GetRankingTalleres(int idPeriodo)
        {
            return inscripcionRepo.Query()
                .Where(i => i.IdCuentaNavigation.IdPeriodo == idPeriodo)
                .GroupBy(i => new { i.IdTallerNavigation.Nombre, Categoria = i.IdTallerNavigation.IdCategoriaNavigation.Nombre })
                .Select(g => new RankingTallerDTO
                {
                    NombreTaller = g.Key.Nombre,
                    Categoria = g.Key.Categoria,
                    TotalInscripciones = g.Count()
                })
                .OrderByDescending(x => x.TotalInscripciones)
                .ToList();
        }
    }
}