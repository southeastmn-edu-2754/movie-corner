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
    public class WatchlistTitlesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public WatchlistTitlesController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/WatchlistTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchlistTitles>>> GetWatchlistTitles()
        {
            return await _context.WatchlistTitles.ToListAsync();
        }

        // GET: api/WatchlistTitles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchlistTitles>> GetWatchlistTitles(int id)
        {
            var watchlistTitles = await _context.WatchlistTitles.FindAsync(id);

            if (watchlistTitles == null)
            {
                return NotFound();
            }

            return watchlistTitles;
        }

        // PUT: api/WatchlistTitles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchlistTitles(int id, WatchlistTitles watchlistTitles)
        {
            if (id != watchlistTitles.WatchlistId)
            {
                return BadRequest();
            }

            _context.Entry(watchlistTitles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchlistTitlesExists(id))
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

        // POST: api/WatchlistTitles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WatchlistTitles>> PostWatchlistTitles(WatchlistTitles watchlistTitles)
        {
            _context.WatchlistTitles.Add(watchlistTitles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WatchlistTitlesExists(watchlistTitles.WatchlistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWatchlistTitles", new { id = watchlistTitles.WatchlistId }, watchlistTitles);
        }

        // DELETE: api/WatchlistTitles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WatchlistTitles>> DeleteWatchlistTitles(int id)
        {
            var watchlistTitles = await _context.WatchlistTitles.FindAsync(id);
            if (watchlistTitles == null)
            {
                return NotFound();
            }

            _context.WatchlistTitles.Remove(watchlistTitles);
            await _context.SaveChangesAsync();

            return watchlistTitles;
        }

        private bool WatchlistTitlesExists(int id)
        {
            return _context.WatchlistTitles.Any(e => e.WatchlistId == id);
        }
    }
}
