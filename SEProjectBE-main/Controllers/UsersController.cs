using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEProjectBE.Data;
using SEProjectBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public List<Users> _users { get; set; }


        public UsersController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        // GET: api/<Users>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "An error happened while getting all users" });
            }
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(st => st.Id == id);
                if (user == null) return NotFound(new { Error = "No user exists with this id!" });
                return Ok(user);

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "An error occured while getting user!" });
            }
        }

        // POST api/<Users>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, new { Error = "Please enter valid data!" });
                }
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                //var users = await _context.Users.ToListAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Error occured while adding user!" });
            }
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, new { Error = "Please enter valid data!" });
                }
                var localUser = await _context.Users.SingleOrDefaultAsync(st => st.Id == id);
                if (localUser == null) return NotFound(new { Error = "User not found!" });
                _context.Remove(localUser);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Internal error" });

            }
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(st => st.Id == id);
                if (user == null) return NotFound(new { Error = "User not found" });
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "Error occured while deleting user!" });

            }
        }
    }
}



