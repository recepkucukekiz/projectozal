#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ozal.entity;

namespace ozal.webui.ViewModels
{
    public class ProCareHome
    {
        public List<Product> HomeProducts { get; set; }
        public List<Care> HomeCares { get; set; }
    }

}