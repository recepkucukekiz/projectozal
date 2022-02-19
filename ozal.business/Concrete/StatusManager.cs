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
    public class StatusManager : IStatusService
    {
        private IStatusRepository _statusRepository ;

        public StatusManager(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public void Create(Status entity)
        {
            _statusRepository.Create(entity);
        }

        public void Delete(Status entity)
        {
            _statusRepository.Delete(entity);
        }

        public List<Status> GetAll()
        {
            return _statusRepository.GetAll();
        }

        public Status GetById(int id)
        {
            return _statusRepository.GetById(id);
        }

        public void Update(Status entity)
        {
            _statusRepository.Update(entity);
        }
    }
}
