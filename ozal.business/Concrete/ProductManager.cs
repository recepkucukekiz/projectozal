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
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository categoryRepository)
        {
            _productRepository = categoryRepository;
        }

        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetHomeItems()
        {
            return _productRepository.GetHomeItems();
        }

        public List<Product> GetSearchResult(string q)
        {
            return _productRepository.GetSearchResult(q);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
