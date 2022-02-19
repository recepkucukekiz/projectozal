using ozal.data.Abstract;
using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Concrete.EfCore
{
    public class EfCoreCareRepository : EfCoreGenericRepository<Care, OzalContext>, ICareRepository
    {
        public List<Care> GetHomeItems()
        {
            using (var context = new OzalContext())
            {
                return context.Cares.Where(c => c.Ishome == true).ToList();
            }
        }

        public List<Care> GetSearchResult(string q)
        {
            using (var context = new OzalContext())
            {
                return context.Cares.Where(c => c.Name.ToLower().Contains(q.ToLower()) || c.Description.ToLower().Contains(q.ToLower())).ToList();
            }
        }
    }
}
