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
    public class ProductController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        public ProductController(IMapper mapper, DemoContext context)
        {

            this._mapper = mapper;
            this._context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Product = await _context.Products
                    
                    .ToListAsync();
                return Ok(_mapper.Map<List<ProductDto>>(Product));


            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal happened" });
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var localProduct = await _context.Products.SingleOrDefaultAsync(pr => pr.Id == id);
                if (localProduct == null) return NotFound(new { Error = "not found" });
                var productDto = _mapper.Map<ProductDto>(localProduct);
                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });
            }
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new { Error = "Please enter valid data!" });
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductDto>(product));
        }
        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, new { Error = "Please enter valid data!" });
                }
                var localproduct = await _context.Products.SingleOrDefaultAsync(pr => pr.Id == id);
                _context.Remove(localproduct);
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " internal error" });
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var localPopduct = await _context.Products.SingleOrDefaultAsync(pr => pr.Id == id);
                if (localPopduct == null) return NotFound(new { Error = "not found" });
                _context.Remove(localPopduct);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<ProductDto>(localPopduct));
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal error" });

            }
        }
    }
}
