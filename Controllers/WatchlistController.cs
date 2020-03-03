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
    public class WatchlistController : ControllerBase
    {
        private readonly MoviesContext _context;

        public WatchlistController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/Watchlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watchlist>>> GetWatchlist()
        {
            return await _context.Watchlist.ToListAsync();
        }

        // GET: api/Watchlist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Watchlist>> GetWatchlist(int id)
        {
            var watchlist = await _context.Watchlist.FindAsync(id);

            if (watchlist == null)
            {
                return NotFound();
            }

            return watchlist;
        }

        // PUT: api/Watchlist/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchlist(int id, Watchlist watchlist)
        {
            if (id != watchlist.WatchlistId)
            {
                return BadRequest();
            }

            _context.Entry(watchlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchlistExists(id))
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

        // POST: api/Watchlist
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Watchlist>> PostWatchlist(Watchlist watchlist)
        {
            _context.Watchlist.Add(watchlist);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WatchlistExists(watchlist.WatchlistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWatchlist", new { id = watchlist.WatchlistId }, watchlist);
        }

        // DELETE: api/Watchlist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Watchlist>> DeleteWatchlist(int id)
        {
            var watchlist = await _context.Watchlist.FindAsync(id);
            if (watchlist == null)
            {
                return NotFound();
            }

            _context.Watchlist.Remove(watchlist);
            await _context.SaveChangesAsync();

            return watchlist;
        }

        private bool WatchlistExists(int id)
        {
            return _context.Watchlist.Any(e => e.WatchlistId == id);
        }
    }
}
