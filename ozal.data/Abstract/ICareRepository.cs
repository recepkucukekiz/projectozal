using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Abstract
{
    public interface ICareRepository : IRepository<Care>
    {
        List<Care> GetHomeItems();
        List<Care> GetSearchResult(string q);
        
    }
}
