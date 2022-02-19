using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.business.Abstract
{
    public interface IRepairService
    {
        Repair GetIdOfChecked(int number);
        Repair GetById(int id);
        List<Repair> GetAll();
        void Delete(Repair entity);
        void Update(Repair entity);
        void Create(Repair entity);
    }
}
