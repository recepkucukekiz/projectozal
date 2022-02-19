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
    public class CareManager : ICareService
    {
        private ICareRepository _careRepository;

        public CareManager(ICareRepository categoryRepository)
        {
            _careRepository = categoryRepository;
        }

        public void Create(Care entity)
        {
            _careRepository.Create(entity);
        }

        public void Delete(Care entity)
        {
            _careRepository.Delete(entity);
        }

        public List<Care> GetAll()
        {
            return _careRepository.GetAll();
        }

        public Care GetById(int id)
        {
            return _careRepository.GetById(id);
        }

        public List<Care> GetHomeItems()
        {
            return _careRepository.GetHomeItems();
        }

        public List<Care> GetSearchResult(string q)
        {
            return _careRepository.GetSearchResult(q);
        }

        public void Update(Care entity)
        {
            _careRepository.Update(entity);
        }
    }
}
