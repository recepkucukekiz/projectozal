using ozal.data.Abstract;
using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, OzalContext>, IProductRepository
    {
        public List<Product> GetHomeItems()
        {
            using (var context = new OzalContext())
            {
                return context.Products.Where(c => c.Ishome == true).ToList();
            }
        }

        public List<Product> GetSearchResult(string q)
        {
            using (var context = new OzalContext())
            {
                return context.Products.Where(p => p.Name.ToLower().Contains(q.ToLower()) || p.Description.ToLower().Contains(q.ToLower())).ToList();
            }
        }
    }
}
