using FluentValidation;
using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ICollection<CartItem> Products { get; set; }
    }
}
public class UsersValidator : AbstractValidator<Users>
{
    public UsersValidator()
    {
       //RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotNull().Length(1, 50);
        RuleFor(x => x.Address).NotNull();
        RuleFor(x => x.City).NotNull();

    }
}