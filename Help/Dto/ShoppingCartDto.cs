using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Help.Dto
{
    public class ShoppingCartDto
    {
        public int NumberProducts { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
