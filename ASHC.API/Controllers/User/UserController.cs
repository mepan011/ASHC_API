using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASHC.API.Controllers.User
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private readonly db_ashcContext _context;
        private readonly IMUsers _userService;

        public UserController(db_ashcContext context, IMUsers users)
        {
            _context = context;
            _userService = users;
        }

        [HttpGet]
        [Route("AsyncUsers")]
        public async Task<ActionResult<IEnumerable<MUser>>> GetUsers()
        {
            return await _context.MUsers.ToListAsync();
        }

        [HttpGet]
        [Route("GetAllUser")]
        public ActionResult<IEnumerable<MUser>> GetAllUser()
        {
            var result = _userService.GetAll().ToList();
            return result;
        }

        [HttpGet]
        [Route("GetAllUserBySP")]
        public ActionResult<IEnumerable<MUser>> GetAllUserBySP()
        {
            var result = _userService.GetAllBySP();
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MUser>> GetUsers(int id)
        {
            var users = await _context.MUsers.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, MUser users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> PostUsers(MUser users)
        {
            _context.MUsers.Add(users);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUsers", new { id = users.Id }, users);
            return Json(new
            {
                status = "success",
                message = "Registration done Suceessfully.",
                UserId = users.Id,
            });
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MUser>> DeleteUsers(int id)
        {
            var users = await _context.MUsers.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.MUsers.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }
        
        private bool UsersExists(int id)
        {
            return _context.MUsers.Any(e => e.Id == id);
        }
    }
}
