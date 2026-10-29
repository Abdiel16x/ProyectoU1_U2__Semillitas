using Microsoft.EntityFrameworkCore;
using Semillitas_Api.Models.Data;

namespace Semillitas_Api.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SemillitasdbContext context;

        public Repository(SemillitasdbContext context)
        {
            this.context = context;
        }


        public IQueryable<T> Query()
        {
            return context.Set<T>().AsQueryable();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T? GetById(object id)
        {
            return context.Find<T>(id);
        }

        public T Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }
    }
}