using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCorner.Data;
using MovieCorner.Models;

namespace _2754_movie_corner_2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTitleRatingController : ControllerBase
    {
        private readonly MoviesContext _context;

        public UserTitleRatingController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/UserTitleRating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTitleRating>>> GetUserTitleRating()
        {
            return await _context.UserTitleRating.ToListAsync();
        }

        // GET: api/UserTitleRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTitleRating>> GetUserTitleRating(int id)
        {
            var userTitleRating = await _context.UserTitleRating.FindAsync(id);

            if (userTitleRating == null)
            {
                return NotFound();
            }

            return userTitleRating;
        }

        // PUT: api/UserTitleRating/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTitleRating(int id, UserTitleRating userTitleRating)
        {
            if (id != userTitleRating.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userTitleRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTitleRatingExists(id))
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

        // POST: api/UserTitleRating
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserTitleRating>> PostUserTitleRating(UserTitleRating userTitleRating)
        {
            _context.UserTitleRating.Add(userTitleRating);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTitleRatingExists(userTitleRating.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTitleRating", new { id = userTitleRating.UserId }, userTitleRating);
        }

        // DELETE: api/UserTitleRating/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTitleRating>> DeleteUserTitleRating(int id)
        {
            var userTitleRating = await _context.UserTitleRating.FindAsync(id);
            if (userTitleRating == null)
            {
                return NotFound();
            }

            _context.UserTitleRating.Remove(userTitleRating);
            await _context.SaveChangesAsync();

            return userTitleRating;
        }

        private bool UserTitleRatingExists(int id)
        {
            return _context.UserTitleRating.Any(e => e.UserId == id);
        }
    }
}
