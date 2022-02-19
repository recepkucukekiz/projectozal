using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.business.Abstract
{
    public interface IProductService
    {
        List<Product> GetSearchResult(string q);
        List<Product> GetHomeItems();
        List<Product> GetAll();
        Product GetById(int id);
        void Delete(Product entity);
        void Update(Product entity);
        void Create(Product entity);
    }
}
