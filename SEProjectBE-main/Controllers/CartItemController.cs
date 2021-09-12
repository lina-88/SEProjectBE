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
    public class CartItemController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        public CartItemController(IMapper mapper, DemoContext context)
        {

            this._mapper = mapper;
            this._context = context;
        }
        // GET: api/<CartItem>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var CartItem = await _context.CartItems.ToListAsync();
                return Ok(_mapper.Map<List<CartItemDto>>(CartItem));


            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal Error happened" });
            }
        }

        // GET api/<CartItem>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var locatCartItem = await _context.CartItems.Where(pr => pr.UserId == userId)
                    .Include(ci => ci.Product)
                    .ToListAsync(); ;
                if (locatCartItem == null) return NotFound(new { Error = "not found" });
                var cartitemdto = _mapper.Map<List<CartItemDto>>(locatCartItem);
                return Ok(cartitemdto);

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });
            }
        }

        // POST api/<CartItem>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartItem CartItem)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400, new { Error = "Please enter valid data!" });
            }
            await _context.CartItems.AddAsync(CartItem);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<CartItemDto>(CartItem));
        }

        // PUT api/<CartItemController>/5
        [HttpPut("{userid}/{productid}")]
        public async Task<IActionResult> Put(int userid,int productid, [FromBody] CartItem cartItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, new { Error = "Please enter valid data!" });
                }
                var localCartItem = await _context.CartItems.SingleOrDefaultAsync(pr => pr.UserId == userid && pr.ProductId == productid);
                _context.Remove(localCartItem);
                await _context.CartItems.AddAsync(cartItem);
                await _context.SaveChangesAsync();

                var CartItemDto = _mapper.Map<CartItemDto>(cartItem);
                return Ok(CartItemDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " internal error" });
            }
        }

        // DELETE api/<CartItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var localCartItem = await _context.CartItems.SingleOrDefaultAsync(pr => pr.Id == id);
                if (localCartItem == null) return NotFound(new { Error = "not found" });
                _context.Remove(localCartItem);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<CartItemDto>(localCartItem));
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal error" });

            }
        }
    }
}
