using ozal.data.Abstract;
using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Concrete.EfCore
{
    public class EfCoreStatusRepository : EfCoreGenericRepository<Status, OzalContext>, IStatusRepository
    {
    }
}
