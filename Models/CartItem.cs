using FluentValidation;
using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int NumberOfProducts { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


      
    }
}

public class CartItemValidator : AbstractValidator<CartItem>
{
    public CartItemValidator()
    {
        //RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.NumberOfProducts).NotNull();
        RuleFor(x => x.TotalPrice).NotNull();


    }
}





