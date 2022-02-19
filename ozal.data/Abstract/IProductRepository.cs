using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetHomeItems();
        List<Product> GetSearchResult(string q);
    }
}
