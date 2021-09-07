using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEProjectBE.Data;
using SEProjectBE.Help.Dto;
using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEProjectBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        public ShoppingCartController(IMapper mapper, DemoContext context)
        {

            this._mapper = mapper;
            this._context = context;
        }


        // GET: api/<ShoppingCartController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ShoppingCart = await _context.ShoppingCarts
                    .Include(sc => sc.Products)
                    .ToListAsync();
                return Ok(_mapper.Map<List<ShoppingCartDto>>(ShoppingCart));


            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal happened" });
            }

        }




        // PUT api/<ShoppingCartController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ShoppingCart ShoppingCart)
        {
            try
            {
                //validate student, if not valid return badrequest

                var LocalShoppingCart = await _context.ShoppingCarts.SingleOrDefaultAsync(st => st.Id == id);
                if (LocalShoppingCart == null) return NotFound(new { Error = "not found" });
                _context.Remove(LocalShoppingCart);
                await _context.ShoppingCarts.AddAsync(ShoppingCart);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<ShoppingCartDto>(ShoppingCart));
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal error" });

            }
        }

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var LocalShoppingCart = await _context.ShoppingCarts.SingleOrDefaultAsync(st => st.Id == id);
                if (LocalShoppingCart == null) return NotFound(new { Error = "not found" });
                _context.Remove(LocalShoppingCart);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<ShoppingCartDto>(LocalShoppingCart));
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal error" });

            }
        }
    }
}
