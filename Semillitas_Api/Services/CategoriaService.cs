using Semillitas_Api.Mappers;
using Semillitas_Api.Models.Entities;
using Semillitas_Api.Repositories;
using Semillitas_Core.DTOs;

namespace Semillitas_Api.Services
{
    public class CategoriaService
    {
        private readonly Repository<Categorias> repository;

        public CategoriaService(Repository<Categorias> repository)
        {
            this.repository = repository;
        }
        public List<CategoriaDTO> GetAll()
        {
            var categorias = repository.GetAll().OrderBy(x => x.Nombre)
                .Select(x=>x.ToDTO()).ToList();
            return categorias;
        }

        public CategoriaDTO? GetById(int id)
        {
            var categoria = repository.GetById(id);

            if (categoria == null) return null;

            return categoria.ToDTO();
        }

        public CategoriaDTO? Create(CategoriaDTO dto)
        {
            var data = repository.Add(dto.ToEntity());
            return data.ToDTO();
        }

        public CategoriaDTO? Update(int id, CategoriaDTO dto)
        {
            var entity = repository.GetById(id);
            if (entity == null) return null;

            entity.Nombre = dto.Nombre;
            repository.Update(entity);
            return entity.ToDTO();
        }

        public bool Delete(int id)
        {
            var entidad = repository.GetById(id);
            if (entidad == null) return false;

            repository.Delete(entidad);
            return true;
        }
    }
}
