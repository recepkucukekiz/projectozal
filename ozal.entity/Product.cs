using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Imageurl { get; set; }
        public bool Ishome { get; set; }
        public string Description { get; set; }
    }
}
