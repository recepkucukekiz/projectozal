using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.business.Abstract
{
    public interface IStatusService
    {
        List<Status> GetAll();
        Status GetById(int id);
        void Delete(Status entity);
        void Update(Status entity);
        void Create(Status entity);
    }
}
