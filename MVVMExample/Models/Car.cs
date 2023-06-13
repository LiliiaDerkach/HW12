using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public string Color { get; set; }
    }
}
