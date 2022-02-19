using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.entity
{
    public class Repair
    {
        public int Id { get; set; }
        public int RepairNum { get; set; }
        public string DeviceName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int RepairStatue { get; set; }
    }
}
