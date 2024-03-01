using AspNetCore.Data;
using AspNetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNetCore.Service
{
    public class Service<T> : IService<T> where T : class, IEntity, new() // where den sonrası buraya gönderilecek nesnenin bir class olması, ıentity ile işaretlenmiş olması ve new lenebilir bir nesne olmasını şart koştuğumuzu ifade eder
    {
        private readonly DatabaseContext context; // EF ile veritabanı context imiz

        private readonly DbSet<T> dbSet; // DatabaseContext içindeki db set yapısının generic i

        public Service(DatabaseContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
