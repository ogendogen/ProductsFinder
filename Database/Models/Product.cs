using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public string Tag { get; set; }
        public string Addon1 { get; set; }
        public string Addon2 { get; set; }
        public string Addon3 { get; set; }
        public string Addon4 { get; set; }
        public string Remarks { get; set; }
    }
}
