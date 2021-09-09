using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Help.Dto
{
    public class CartItemDto
    {
  
        public int NumberOfProducts { get; set; }
        public double TotalPrice { get; set; }

        public Users User { get; set; }

     
        public Product Product { get; set; }


       
    }
}
