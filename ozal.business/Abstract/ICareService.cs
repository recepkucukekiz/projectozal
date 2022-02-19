using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.business.Abstract
{
    public interface ICareService
    {
        List<Care> GetSearchResult(string q);
        List<Care> GetHomeItems();
        List<Care> GetAll();
        Care GetById(int id);
        void Delete(Care entity);
        void Update(Care entity);
        void Create(Care entity);
    }
}
