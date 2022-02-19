using ozal.business.Abstract;
using ozal.data.Abstract;
using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.business.Concrete
{
    public class ReapirManager : IRepairService
    {
        private IRepairRepository _repairRepository;

        public ReapirManager(IRepairRepository categoryRepository)
        {
            _repairRepository = categoryRepository;
        }

        public void Create(Repair entity)
        {
            _repairRepository.Create(entity);
        }

        public void Delete(Repair entity)
        {
            _repairRepository.Delete(entity);
        }

        public List<Repair> GetAll()
        {
            return _repairRepository.GetAll();
        }

        public Repair GetById(int id)
        {
            return _repairRepository.GetById(id);
        }

        public Repair GetIdOfChecked(int number)
        {
            return _repairRepository.GetIdOfChecked(number);
        }

        public void Update(Repair entity)
        {
            _repairRepository.Update(entity);
        }
    }
}
