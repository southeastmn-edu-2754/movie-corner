using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCorner.Data;
using MovieCorner.Models;

namespace MovieCorner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWatchlistsController : ControllerBase
    {
        private readonly MoviesContext _context;

        public UserWatchlistsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/UserWatchlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWatchlists>>> GetUserWatchlists()
        {
            return await _context.UserWatchlists.ToListAsync();
        }

        // GET: api/UserWatchlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserWatchlists>> GetUserWatchlists(int id)
        {
            var userWatchlists = await _context.UserWatchlists.FindAsync(id);

            if (userWatchlists == null)
            {
                return NotFound();
            }

            return userWatchlists;
        }

        // PUT: api/UserWatchlists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserWatchlists(int id, UserWatchlists userWatchlists)
        {
            if (id != userWatchlists.UserwatchlistId)
            {
                return BadRequest();
            }

            _context.Entry(userWatchlists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserWatchlistsExists(id))
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

        // POST: api/UserWatchlists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserWatchlists>> PostUserWatchlists(UserWatchlists userWatchlists)
        {
            _context.UserWatchlists.Add(userWatchlists);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserWatchlistsExists(userWatchlists.UserwatchlistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserWatchlists", new { id = userWatchlists.UserwatchlistId }, userWatchlists);
        }

        // DELETE: api/UserWatchlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserWatchlists>> DeleteUserWatchlists(int id)
        {
            var userWatchlists = await _context.UserWatchlists.FindAsync(id);
            if (userWatchlists == null)
            {
                return NotFound();
            }

            _context.UserWatchlists.Remove(userWatchlists);
            await _context.SaveChangesAsync();

            return userWatchlists;
        }

        private bool UserWatchlistsExists(int id)
        {
            return _context.UserWatchlists.Any(e => e.UserwatchlistId == id);
        }
    }
}
