using ozal.data.Abstract;
using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Concrete.EfCore
{
    public class EfCoreRepairRepository : EfCoreGenericRepository<Repair, OzalContext>, IRepairRepository
    {
        public Repair GetIdOfChecked(int number)
        {
            using (var context = new OzalContext())
            {
                var obj = context.Repairs.Where(r => r.RepairNum == number).FirstOrDefault();
                return obj;
            }
        }
    }
}
