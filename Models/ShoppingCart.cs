using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int NumberProducts { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public ICollection<Product> Products{ get; set; }

    }
}
