using FluentValidation;
using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Models
{
    public class Product
    {
        public int Id { get; set; }
     
        public ICollection<CartItem> Users{ get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public String Picture { get; set; }
        public string category { get; set; }



    }
}

public class ProductsValidator : AbstractValidator<Product>
{
    public ProductsValidator()
    {
        //RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotNull().Length(1, 50);
        RuleFor(x => x.Price).NotNull();
        RuleFor(x => x.category).NotNull();
       

    }
}
