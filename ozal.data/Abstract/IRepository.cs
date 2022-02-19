using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Abstract
{
    public interface IRepository<T>
        where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Delete(T entity);
        void Update(T entity);
        void Create(T entity);
    }
}
