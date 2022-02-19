using Microsoft.EntityFrameworkCore;
using ozal.data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Concrete.EfCore
{
    public class EfCoreGenericRepository<Tentity, Tcontext> : IRepository<Tentity> 
        where Tentity : class 
        where Tcontext : DbContext, new()
    {
        public void Create(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Set<Tentity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Set<Tentity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<Tentity> GetAll()
        {
            using (var context = new Tcontext())
            {
                return context.Set<Tentity>().ToList();
            }
        }

        public Tentity GetById(int id)
        {
            using (var context = new Tcontext())
            {
                return context.Set<Tentity>().Find(id);
            }
        }
        public void Update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
